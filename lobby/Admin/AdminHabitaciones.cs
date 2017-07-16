using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminHabitaciones
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<Habitacion> TraerTodas()
        {
            using (var db = new LobbyDB())
            {
                return db.Habitaciones.ToList();
            }
        }
        public static List<Habitacion> TraerTodasEnServicio()
        {
            using (var db = new LobbyDB())
            {
                return db.Habitaciones.Where(h => h.Bloqueada == false).ToList();
            }
        }
        public static Habitacion TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.Habitaciones.Where(h => h.Id == id).FirstOrDefault();
            }
        }
        public static Habitacion TraerPorNumero(int numero)
        {
            using (var db = new LobbyDB())
            {
                return db.Habitaciones.Where(h => h.Numero == numero).FirstOrDefault();
            }
        }
        public static int Crear(Habitacion habitacion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Habitaciones.Add(habitacion);
                    db.SaveChanges();
                    logger.Info("Agrega habitación: " + habitacion.Id);
                    return (from h in db.Habitaciones
                            orderby h.Id descending
                            select h.Id).First();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static void Modificar(Habitacion habitacion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Habitacion habitacionMod = db.Habitaciones.Where(h => h.Id == habitacion.Id).FirstOrDefault();

                    habitacionMod.Numero = habitacion.Numero;
                    habitacionMod.Piso = habitacion.Piso;
                    habitacionMod.TipoId = habitacion.TipoId;
                    habitacionMod.Bloqueada = habitacion.Bloqueada;
                    habitacionMod.Cabana = habitacion.Cabana;
                    habitacionMod.Descripcion = habitacion.Descripcion;

                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }            
        }
        #endregion
    }
}
