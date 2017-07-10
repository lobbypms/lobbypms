using lobby.Model;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminDirecciones
    {
        #region Methods
        public static int Crear(Direccion direccion)
        {
            LobbyDB db = new LobbyDB();
            db.Direcciones.Add(direccion);
            db.SaveChanges();
            return (from p in db.Direcciones
                    orderby p.Id descending
                    select p.Id).First();
        }
        public static Direccion TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.Direcciones.Where(d => d.Id == id).Single();
        }
        #endregion
    }
}
