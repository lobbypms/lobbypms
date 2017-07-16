using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminTiposHabitacion
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<TipoHabitacion> TraerTodos()
        {
            using (var db = new LobbyDB())
            {
                return db.HabitacionTipos.ToList();
            }
        }
        public static TipoHabitacion TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.HabitacionTipos.Where(t => t.Id == id).FirstOrDefault();
            }
        }
        public static int Crear(TipoHabitacion tipoHabitacion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.HabitacionTipos.Add(tipoHabitacion);
                    db.SaveChanges();
                    logger.Info("Crea tipo habitación: " + tipoHabitacion.Id);
                    return (from t in db.HabitacionTipos
                            orderby t.Id descending
                            select t.Id).First();

                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static void Modificar(TipoHabitacion tipoHabitacion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    TipoHabitacion tipoHabitacionMod = db.HabitacionTipos.Where(t => t.Id == tipoHabitacion.Id).FirstOrDefault();
                    tipoHabitacionMod = tipoHabitacion;
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
