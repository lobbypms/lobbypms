using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminPaises
    {
        public static List<Pais> TraerTodos()
        {
            using (var db = new LobbyDB())
            {
                return db.Paises.ToList();
            }
        }
    }
}