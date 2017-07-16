using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminPropiedad
    {
        public static List<Propiedad> TraerTodas()
        {
            using (var db = new LobbyDB())
            {
                return db.Propiedad.ToList();
            }
        }
    }
}
