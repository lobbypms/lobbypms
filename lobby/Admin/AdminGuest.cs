using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lobby.Model;
using System.Reflection;
using log4net;

namespace lobby.Admin
{
    public static class AdminGuest
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region methods

        public static Perfil TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {

                try
                {
                    return (from p in db.Perfiles
                            join d in db.Direcciones on p.DireccionId equals d.Id
                            where p.Id == id
                            select p).FirstOrDefault();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return null;
                }
            }
        }
        public static string TraerPorHabitacion(int habitacionId)
        {
            using (var db = new LobbyDB())
            {
                return (from p in db.Perfiles
                        join r in db.Reservas on p.Id equals r.PerfilId
                        where r.HabitacionID == habitacionId
                        select p.Nombre + " " + p.Apellido).FirstOrDefault().ToString();
            }
        }
        public static void CheckOut(int resvId, int habitacionId)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Reserva reserva = db.Reservas.Where(r => r.Id == resvId).FirstOrDefault();
                    reserva.Status = 0;
                    reserva.HabitacionID = null;

                    Habitacion habitacion = db.Habitaciones.Where(h => h.Id == habitacionId).FirstOrDefault();
                    habitacion.Ocupada = false;

                    db.SaveChanges();
                    logger.Info("Check out reserva: " + resvId);
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void CheckIn(int resvId, int habitacionId, int tarifaId, bool desayuno, string extra)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Reserva reserva = db.Reservas.Where(r => r.Id == resvId).FirstOrDefault();
                    reserva.HabitacionID = habitacionId;
                    reserva.TarifaID = tarifaId;
                    reserva.Desayuno = desayuno;
                    reserva.Extra = extra;
                    reserva.FechaLlegada = DateTime.Now;
                    reserva.Status = 1;

                    Habitacion habitacion = db.Habitaciones.Where(h => h.Id == habitacionId).FirstOrDefault();
                    habitacion.Ocupada = true;

                    db.SaveChanges();
                    logger.Info("Check in reserva: " + resvId);
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        #endregion
    }
}
