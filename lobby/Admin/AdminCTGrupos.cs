using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminCTGrupos
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<ctGrupo> TraerTodos()
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.ctGrupos.ToList();
            }
        }
        public static ctGrupo TraerPorId(int id)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.ctGrupos.Where(g => g.Id == id).FirstOrDefault();
            }
        }
        public static ctGrupo TraerPorCodigo(string codigo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.ctGrupos.Where(g => g.Codigo == codigo).FirstOrDefault();
            }
        }
        public static void Agregar(ctGrupo grupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                try
                {
                    db.ctGrupos.Add(grupo);
                    db.SaveChanges();
                    logger.Info("Agrega Grupo CT: " + grupo.Id);
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void Modificar(ctGrupo grupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                try
                {
                    ctGrupo ctGrupo = db.ctGrupos.Where(g => g.Codigo == grupo.Codigo).FirstOrDefault();
                    ctGrupo = grupo;
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
