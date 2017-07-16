using lobby.Model;
using log4net;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminPatentes
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static int Crear(Patente patente)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Patentes.Add(patente);
                    db.SaveChanges();
                    logger.Info("Agrega patente: " + patente.Id);
                    return (from p in db.Patentes
                            orderby p.Id descending
                            select p.Id).First();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static Patente TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.Patentes.Where(p => p.Id == id).FirstOrDefault();
            }
        }
        public static Patente TraerPorPatente(string patente)
        {
            using (var db = new LobbyDB())
            {
                return db.Patentes.Where(p => p.Descripcion == patente).FirstOrDefault();
            }
        }
        public static void Modificar(Patente patente)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Patente patenteMod = db.Patentes.Where(p => p.Id == patente.Id).FirstOrDefault();
                    patenteMod.Descripcion = patente.Descripcion;
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
