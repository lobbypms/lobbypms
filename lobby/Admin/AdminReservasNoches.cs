using lobby.Model;
using log4net;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminReservasNoches
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void Crear(ReservaNoche reservasNoches)
        {
            #region Methods
            using (var db = new LobbyDB())
            {
                try
                {
                    db.ReservasNoches.Add(reservasNoches);
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
            #endregion
        }
    }
}
