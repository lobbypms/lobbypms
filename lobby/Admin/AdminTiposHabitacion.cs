using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminTiposHabitacion
    {
        #region Methods
        public static List<TipoHabitacion> TraerTodos()
        {
            LobbyDB db = new LobbyDB();
            return db.HabitacionTipos.ToList();
        }
        public static TipoHabitacion TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.HabitacionTipos.Where(t => t.Id == id).Single();
        }
        public static int Crear(TipoHabitacion tipoHabitacion)
        {
            LobbyDB db = new LobbyDB();
            db.HabitacionTipos.Add(tipoHabitacion);
            db.SaveChanges();
            return (from t in db.HabitacionTipos
                    orderby t.Id descending
                    select t.Id).First();
        }
        public static void Modificar(TipoHabitacion tipoHabitacion)
        {
            LobbyDB db = new LobbyDB();
            TipoHabitacion tipoHabitacionMod = db.HabitacionTipos.Where(t => t.Id == tipoHabitacion.Id).Single();
            tipoHabitacionMod = tipoHabitacion;
            db.SaveChanges();
        }
        #endregion
    }
}
