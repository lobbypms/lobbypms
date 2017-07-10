using lobby.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Admin
{
    public static class AdminCTSubgrupos
    {
        #region Methods
        public static List<ctSubgrupo> TraerTodos()
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.ctSubgrupos.ToList();
            }
        }
        public static ctSubgrupo TraerPorCodigo(string codigoSubgrupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.ctSubgrupos.Where(s => s.Codigo == codigoSubgrupo).FirstOrDefault();
            }
        }
        public static void Agregar(ctSubgrupo subgrupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                try
                {
                    db.ctSubgrupos.Add(subgrupo);
                    db.SaveChanges();
                    MessageBox.Show("Código creado con éxito", "Agregar código subgrupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.InnerException.Message);
                }
            }

        }
        public static void Modificar(ctSubgrupo subgrupo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                ctSubgrupo ctSubgrupo = db.ctSubgrupos.Where(s => s.Codigo == subgrupo.Codigo).Single();
                ctSubgrupo.Descripcion = subgrupo.Descripcion;
                ctSubgrupo.CTGrupoId = subgrupo.CTGrupoId;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
