using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lobby.Model;

namespace lobby.Admin
{
    public static class AdminRangosFiscales
    {
        public static List<RangoFiscal> TraerTodos()
        {
            LobbyDB db = new LobbyDB();
            return db.RangosFiscales.ToList();
        }

        public static void Agregar(RangoFiscal rango)
        {
            LobbyDB db = new LobbyDB();
            db.RangosFiscales.Add(rango);
            db.SaveChanges();
        }
    }
}
