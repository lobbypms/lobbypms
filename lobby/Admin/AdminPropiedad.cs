using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lobby.Admin
{
    public static class AdminPropiedad
    {
        public static List<Propiedad> TraerTodas()
        {
            LobbyDB db = new LobbyDB();
            return db.Propiedad.ToList();
        }
    }
}
