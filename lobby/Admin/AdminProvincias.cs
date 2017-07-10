using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lobby.Admin
{
    public static class AdminProvincias
    {
        public static List<Provincia> TraerTodas()
        {
            LobbyDB db = new LobbyDB();
            return db.Provincias.ToList();
        }
    }
}
