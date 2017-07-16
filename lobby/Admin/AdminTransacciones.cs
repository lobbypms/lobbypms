using lobby.Model;
using log4net;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminTransacciones
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static int Post(Transaccion transaccion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Transacciones.Add(transaccion);
                    db.SaveChanges();

                    return (from t in db.Transacciones
                            orderby t.NumTransaccion descending
                            select t.NumTransaccion).First();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static void ModificaPost(Transaccion transaccion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Transaccion transaccionMod = db.Transacciones.Where(t => t.CodTransaccionId == transaccion.CodTransaccionId
                        && t.NumTransaccion == transaccion.NumTransaccion).FirstOrDefault();
                    transaccionMod = transaccion;
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void Borrar(Transaccion transaccion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Transacciones.Remove(transaccion);
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
