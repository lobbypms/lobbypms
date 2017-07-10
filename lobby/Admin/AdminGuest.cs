using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lobby.Model;

namespace lobby.Admin
{
    public static class AdminGuest
    {
        public class TipoPerfil
        {
            public int TipoDocumento { get; set; }
            public int NumeroDocumento { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string NumeroTarjeta { get; set; }
            public string Extra { get; set; }
            public string Email { get; set; }
            public bool Estacionamiento { get; set; }
            public int PatenteId { get; set; }
            public string Patente { get; set; }
            public int DireccionId { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }
            public string Piso { get; set; }
            public string Departamento { get; set; }
            public int ProvinciaId { get; set; }
            public string Localidad { get; set; }
            public int CodigoPostal { get; set; }
            public int PaisId { get; set; }

        }
        public static TipoPerfil TraerPorId(int id)
        {
            //seguir
            LobbyDB db = new LobbyDB();
            TipoPerfil result = (from p in db.Perfiles
                          join d in db.Direcciones on p.DireccionId equals d.Id
                          where p.Id == id
                          select new TipoPerfil
                          {
                              
                          }).Single();
            return result;

        }
        public static string TraerPorHabitacion(int habitacionId)
        {
            LobbyDB db = new LobbyDB();
            return (from p in db.Perfiles
                          join r in db.Reservas on p.Id equals r.HuespedID
                          where r.HabitacionID == habitacionId
                          select new
                          {
                              Huesped = p.Nombre + " " + p.Apellido
                          }).Single().ToString();
        }
        public static void CheckOut(int resvId, int habitacionId)
        {
            LobbyDB db = new LobbyDB();

            Reserva reserva = db.Reservas.Where(r => r.Id == resvId).Single();
            reserva.Status = 0;
            reserva.HabitacionID = null;

            Habitacion habitacion = db.Habitaciones.Where(h => h.Id == habitacionId).Single();
            habitacion.Ocupada = false;

            db.SaveChanges();
        }
        public static void CheckIn(int resvId, int habitacionId, int tarifaId, bool desayuno, string extra)
        {
            LobbyDB db = new LobbyDB();
            Reserva reserva = AdminReservas.TraerPorId(resvId);
            reserva.HabitacionID = habitacionId;
            reserva.TarifaID = tarifaId;
            reserva.Desayuno = desayuno;
            reserva.Extra = extra;
            reserva.FechaLlegada = DateTime.Now;
            reserva.Status = 1;

            Habitacion habitacion = AdminHabitaciones.TraerPorId(habitacionId);
            habitacion.Ocupada = true;

            db.SaveChanges();
        }
    }
}
