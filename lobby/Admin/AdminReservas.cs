using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lobby.Model;

namespace lobby.Admin
{
    public static class AdminReservas
    {
        #region Propiedades
        //TODO Devolver siempre tipo Reservas, CORREGIR
        public class ReservasPendientes
        {
            public int Id { get; set; }
            public int HabitacionId { get; set; }
            public string Huesped { get; set; }
            public DateTime FechaLlegada { get; set; }
            public DateTime FechaSalida { get; set; }
        }
        public class TipoReservas
        {
            public string Huesped { get; set; }
            public string Tarifa { get; set; }
            public DateTime FechaLlegada { get; set; }
            public DateTime FechaSalida { get; set; }
            public int Adultos { get; set; }
            public int Ninios { get; set; }
            public bool CamaExtra { get; set; }
            public bool Desayuno { get; set; }
            public string Comentarios { get; set; }
            public int ResvId { get; set; }
            public int RateId { get; set; }
        }
        public class TipoReservasConDatosCompletos
        {
            public string Huesped { get; set; }
            public int HuespedId { get; set; }
            public int HabitacionId { get; set; }
            public bool CamaExtra { get; set; }
            public bool Desayuno { get; set; }
            public int Adultos { get; set; }
            public int Ninios { get; set; }
            public DateTime FechaLlegada { get; set; }
            public DateTime FechaSalida { get; set; }
            public int Noches { get; set; }
            public int TarifaId { get; set; }
            public string Comentarios { get; set; }
            public int? DireccionId { get; set; }
            public int? PatenteId { get; set; }
            public int Status { get; set; }
        }
        public static List<ReservasPendientes> reservasPendientes { get; set; }
        #endregion

        #region Metodos
        public static TipoReservasConDatosCompletos TraerPorIdConDatosHuesped(int resvId)
        {
            LobbyDB db = new LobbyDB();
            return (from r in db.Reservas
                          join p in db.Perfiles on r.HuespedID equals p.Id
                          where r.Id == resvId
                          select new TipoReservasConDatosCompletos
                          {
                              Huesped = p.Nombre + " " + p.Apellido,
                              HuespedId = p.Id,
                              HabitacionId = r.HabitacionID.Value,
                              CamaExtra = r.CamaExtra,
                              Desayuno = r.Desayuno,
                              Adultos = r.Adultos,
                              Ninios = r.Ninios,
                              FechaLlegada = r.FechaLlegada,
                              FechaSalida = r.FechaSalida,
                              Noches = r.Noches,
                              TarifaId = r.TarifaID,
                              Comentarios = r.Extra,
                              DireccionId = p.DireccionId,
                              PatenteId = p.PatenteId.Value,
                              Status = r.Status.Value
                           }).Single();
        }
        public static Reserva TraerPorId(int _resvId)
        {
            LobbyDB db = new LobbyDB();
            return db.Reservas.Where(r => r.Id == _resvId).Single();
        }
        public static Reserva TraerPorFecha(DateTime fecha, int huespedId)
        {
            LobbyDB db = new LobbyDB();
            return db.Reservas.Where(r => r.HuespedID == huespedId && r.FechaLlegada == fecha).Single();
        }
        public static List<Reserva> TraerTodas()
        {
            LobbyDB db = new LobbyDB();
            return db.Reservas.ToList();
        }
        public static List<ReservasPendientes> TraerPendientesCheckIn()
        {
            LobbyDB db = new LobbyDB();
            reservasPendientes = (from r in db.Reservas
                                  join p in db.Perfiles on r.HuespedID equals p.Id
                                  where r.FechaLlegada < DateTime.Now &&
                                  r.Status == null
                                  select new ReservasPendientes
                                  {
                                      Id = r.Id,
                                      HabitacionId = r.HabitacionID.Value,
                                      Huesped = p.Nombre,
                                      FechaLlegada = r.FechaLlegada,
                                      FechaSalida = r.FechaSalida
                                  }).ToList();
            return reservasPendientes;
        }
        public static List<ReservasPendientes> TraerPendientesCheckOut()
        {
            LobbyDB db = new LobbyDB();
            reservasPendientes = (from r in db.Reservas
                                  join p in db.Perfiles on r.HuespedID equals p.Id
                                  where r.FechaSalida < DateTime.Now &&
                                  r.Status == 1
                                  select new ReservasPendientes
                                  {
                                      Id = r.Id,
                                      HabitacionId = r.HabitacionID.Value,
                                      Huesped = p.Nombre,
                                      FechaLlegada = r.FechaLlegada,
                                      FechaSalida = r.FechaSalida
                                  }).ToList();
            return reservasPendientes;
        }
        public static List<TipoReservas> TraerInHouse()
        {
            LobbyDB db = new LobbyDB();
            return (from r in db.Reservas
                          join p in db.Perfiles on r.HuespedID equals p.Id
                          join t in db.Tarifas on r.TarifaID equals t.Id
                          where p.Id == r.HuespedID
                          && t.Id == r.TarifaID
                          && r.Status == 1
                          select new TipoReservas
                          {
                              Huesped = p.Nombre + " " + p.Apellido,
                              Tarifa = t.Nombre,
                              FechaLlegada = r.FechaLlegada,
                              FechaSalida = r.FechaSalida,
                              Adultos = r.Adultos,
                              Ninios = r.Ninios,
                              CamaExtra = r.CamaExtra,
                              Desayuno = r.Desayuno,
                              Comentarios = r.Extra,
                              ResvId = r.Id,
                              RateId = t.Id
                          }).ToList();
        }
        public static List<TipoReservas> TraerLlegadas()
        {
            LobbyDB db = new LobbyDB();
            return (from r in db.Reservas
                    join p in db.Perfiles on r.HuespedID equals p.Id
                    join t in db.Tarifas on r.TarifaID equals t.Id
                    where r.FechaLlegada == DateTime.Now
                    && p.Id == r.HuespedID
                    && t.Id == r.TarifaID
                    && r.Status == null
                    select new TipoReservas
                    {
                        Huesped = p.Nombre + " " + p.Apellido,
                        Tarifa = t.Nombre,
                        FechaLlegada = r.FechaLlegada,
                        FechaSalida = r.FechaSalida,
                        Adultos = r.Adultos,
                        Ninios = r.Ninios,
                        CamaExtra = r.CamaExtra,
                        Desayuno = r.Desayuno,
                        Comentarios = r.Extra,
                        ResvId = r.Id,
                        RateId = t.Id
                    }).ToList();
        }
        public static List<TipoReservas> TraerSalidas()
        {
            LobbyDB db = new LobbyDB();
            return (from r in db.Reservas
                    join p in db.Perfiles on r.HuespedID equals p.Id
                    join t in db.Tarifas on r.TarifaID equals t.Id
                    where r.FechaSalida == DateTime.Now
                    && p.Id == r.HuespedID
                    && t.Id == r.TarifaID
                    && r.Status == 1
                    select new TipoReservas
                    {
                        Huesped = p.Nombre + " " + p.Apellido,
                        Tarifa = t.Nombre,
                        FechaLlegada = r.FechaLlegada,
                        FechaSalida = r.FechaSalida,
                        Adultos = r.Adultos,
                        Ninios = r.Ninios,
                        CamaExtra = r.CamaExtra,
                        Desayuno = r.Desayuno,
                        Comentarios = r.Extra,
                        ResvId = r.Id,
                        RateId = t.Id
                    }).ToList();
        }
        public static int IdPorNumeroHabitacion(int numeroHabitacion)
        {
            LobbyDB db = new LobbyDB();
            return db.Reservas.Where(r => r.Habitacion.Numero == numeroHabitacion).Single().Id;
        }
        public static void ModificarFechaLlegada(int _resvId, DateTime _fecha)
        {
            //TODO PROBAR SI FUNCIONA Y SE MODIFICA
            LobbyDB db = new LobbyDB();
            Reserva res = TraerPorId(_resvId);
            res.FechaLlegada = _fecha;
            db.SaveChanges();
        }
        public static void ModificarFechaSalida(int _resvId, DateTime _fecha)
        {
            //Gabriel PROBAR SI FUNCIONA Y SE MODIFICA
            LobbyDB db = new LobbyDB();
            Model.Reserva res = TraerPorId(_resvId);
            res.FechaSalida = _fecha;
            db.SaveChanges();
        }
        public static void Modificar(Reserva reserva)
        {
            LobbyDB db = new LobbyDB();
            Reserva reservaMod = db.Reservas.Where(r => r.Id == reserva.Id).Single();
            reservaMod = reserva;
            db.SaveChanges();
        }
        public static void CambiarHabitacion(int resvId, int habitacionDesdeId, int habitacionHastaId)
        {
            LobbyDB db = new LobbyDB();
            Habitacion habitacionDesde = db.Habitaciones.Where(h => h.Id == habitacionDesdeId).Single();
            Habitacion habitacionHasta = db.Habitaciones.Where(h => h.Id == habitacionHastaId).Single();
            Reserva reserva = db.Reservas.Where(r => r.Id == resvId).Single();

            habitacionDesde.Ocupada = false;
            habitacionHasta.Ocupada = true;
            reserva.HabitacionID = habitacionHastaId;
            db.SaveChanges();
        }
        public static int Crear(Reserva reserva)
        {
            LobbyDB db = new LobbyDB();
            db.Reservas.Add(reserva);
            db.SaveChanges();

            return (from r in db.Reservas
                    orderby r.Id descending
                    select r.Id).First();
        }
        public static void Cancelar(int resvId)
        {
            LobbyDB db = new LobbyDB();
            Reserva reserva = db.Reservas.Where(r => r.Id == resvId).Single();
            reserva.Status = -1;

            ReservaNoche reservaNoches = db.ReservasNoches.Where(rn => rn.ResvId == resvId).Single();
            reservaNoches.Status = -1;

            db.SaveChanges();
        }
        #endregion
    }
}
