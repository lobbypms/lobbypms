using lobby.Model;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminPatentes
    {
        #region Methods
        public static int Crear(Patente patente)
        {
            LobbyDB db = new LobbyDB();
            db.Patentes.Add(patente);
            db.SaveChanges();
            return (from p in db.Patentes
                    orderby p.Id descending
                    select p.Id).First();
        }
        public static Patente TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.Patentes.Where(p => p.Id == id).Single();
        }
        #endregion
    }
}
