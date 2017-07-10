using lobby.Model;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminTransacciones
    {
        #region Methods
        public static int Post(Transaccion transaccion)
        {
            LobbyDB db = new LobbyDB();
            db.Transacciones.Add(transaccion);
            db.SaveChanges();

            return (from t in db.Transacciones
                    orderby t.NumTransaccion descending
                    select t.NumTransaccion).First();
        }
        public static void ModificaPost(Transaccion transaccion)
        {
            LobbyDB db = new LobbyDB();
            Transaccion transaccionMod = db.Transacciones.Where(t => t.CodTransaccionId == transaccion.CodTransaccionId
            && t.NumTransaccion == transaccion.NumTransaccion).Single();
            transaccionMod = transaccion;
            db.SaveChanges();
        }
        public static void Borrar(Transaccion transaccion)
        {
            LobbyDB db = new LobbyDB();
            db.Transacciones.Remove(transaccion);
            db.SaveChanges();

        }
        #endregion
    }
}
