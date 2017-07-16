using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminTiposDocumento
    {
        #region Methods
        public static List<TipoDocumento> TraerTodos()
        {
            LobbyDB db = new LobbyDB();
            return db.TipoDocumentos.ToList();
        }
        public static TipoDocumento TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.TipoDocumentos.Where(t => t.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
