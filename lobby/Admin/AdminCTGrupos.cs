using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminCTGrupos
    {
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
                return db.ctGrupos.Where(g => g.Codigo == codigo).Single();
            }
        }
        public static void Agregar(ctGrupo grupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                db.ctGrupos.Add(grupo);
                db.SaveChanges();
            }
        }
        public static void Modificar(ctGrupo grupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                ctGrupo ctGrupo = db.ctGrupos.Where(g => g.Codigo == grupo.Codigo).Single();
                ctGrupo = grupo;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
