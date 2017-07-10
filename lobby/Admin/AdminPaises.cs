using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lobby.Admin
{
    public static class AdminPaises
    {
        public static List<Pais> TraerTodos()
        {
            LobbyDB db = new LobbyDB();
            return db.Paises.ToList();
        }
    }
}
