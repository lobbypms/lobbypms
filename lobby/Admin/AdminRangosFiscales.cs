using System.Collections.Generic;
using System.Linq;
using lobby.Model;
using System.Reflection;
using log4net;

namespace lobby.Admin
{
    public static class AdminRangosFiscales
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static List<RangoFiscal> TraerTodos()
        {
            using (var db = new LobbyDB())
            {
                return db.RangosFiscales.ToList();
            }
        }
        public static void Agregar(RangoFiscal rango)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.RangosFiscales.Add(rango);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
    }
}
