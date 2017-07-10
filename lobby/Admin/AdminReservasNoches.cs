using lobby.Model;

namespace lobby.Admin
{
    public static class AdminReservasNoches
    {
        public static void Crear(ReservaNoche reservasNoches)
        {
            #region Methods
            LobbyDB db = new LobbyDB();
            db.ReservasNoches.Add(reservasNoches);
            db.SaveChanges();
            #endregion
        }
    }
}
