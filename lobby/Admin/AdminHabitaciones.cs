using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminHabitaciones
    {
        #region Methods
        public static List<Habitacion> TraerTodas()
        {
            LobbyDB db = new LobbyDB();
            return db.Habitaciones.ToList();
        }
        public static List<Habitacion> TraerTodasEnServicio()
        {
            LobbyDB db = new LobbyDB();
            return db.Habitaciones.Where(h => h.Bloqueada == false).ToList();
        }
        public static Habitacion TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.Habitaciones.Where(h => h.Id == id).FirstOrDefault();
        }
        public static Habitacion TraerPorNumero(int numero)
        {
            LobbyDB db = new LobbyDB();
            return db.Habitaciones.Where(h => h.Numero == numero).FirstOrDefault();
        }
        public static int Crear(Habitacion habitacion)
        {
            LobbyDB db = new LobbyDB();
            db.Habitaciones.Add(habitacion);
            db.SaveChanges();
            return (from h in db.Habitaciones
                    orderby h.Id descending
                    select h.Id).First();
        }
        public static void Modificar(Habitacion habitacion)
        {
            using (var context = new LobbyDB())
            {
                Habitacion habitacionMod = context.Habitaciones.Where(h => h.Id == habitacion.Id).Single();

                habitacionMod.Numero = habitacion.Numero;
                habitacionMod.Piso = habitacion.Piso;
                habitacionMod.TipoId = habitacion.TipoId;
                habitacionMod.Bloqueada = habitacion.Bloqueada;
                habitacionMod.Cabana = habitacion.Cabana;
                habitacionMod.Descripcion = habitacion.Descripcion;

                context.SaveChanges();
            }            
        }
        #endregion
    }
}
