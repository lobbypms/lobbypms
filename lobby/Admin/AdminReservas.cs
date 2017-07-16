using System;
using System.Collections.Generic;
using System.Linq;
using lobby.Model;
using log4net;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminReservas
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Metodos
        public static Reserva TraerPorId(int _resvId)
        {
            using (var db = new LobbyDB())
            {
                return db.Reservas.Where(r => r.Id == _resvId).FirstOrDefault();
            }
        }
        public static Reserva TraerPorFecha(DateTime fecha, int huespedId)
        {
            using (var db = new LobbyDB())
            {
                return db.Reservas.Where(r => r.PerfilId == huespedId && r.FechaLlegada == fecha).FirstOrDefault();
            }
        }
        public static List<Reserva> TraerTodas()
        {
            using (var db = new LobbyDB())
            {
                return db.Reservas.ToList();
            }
        }
        public static List<Reserva> TraerPendientesCheckIn()
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                        join p in db.Perfiles on r.PerfilId equals p.Id
                        where r.FechaLlegada < DateTime.Now &&
                        r.Status == null
                        select r).ToList();
            }
        }
        public static List<Reserva> TraerPendientesCheckOut()
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                                      join p in db.Perfiles on r.PerfilId equals p.Id
                                      where r.FechaSalida < DateTime.Now &&
                                      r.Status == 1
                                      select r).ToList();
            }
        }
        public static List<Reserva> TraerInHouse()
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                        join p in db.Perfiles on r.PerfilId equals p.Id
                        join t in db.Tarifas on r.TarifaID equals t.Id
                        where p.Id == r.PerfilId
                        && t.Id == r.TarifaID
                        && r.Status == 1
                        select r).ToList();
            }
        }
        public static List<Reserva> TraerLlegadas()
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                        join p in db.Perfiles on r.PerfilId equals p.Id
                        join t in db.Tarifas on r.TarifaID equals t.Id
                        where r.FechaLlegada == DateTime.Now
                        && p.Id == r.PerfilId
                        && t.Id == r.TarifaID
                        && r.Status == null
                        select r).ToList();
            }
        }
        public static List<Reserva> TraerSalidas()
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                        join p in db.Perfiles on r.PerfilId equals p.Id
                        join t in db.Tarifas on r.TarifaID equals t.Id
                        where r.FechaSalida == DateTime.Now
                        && p.Id == r.PerfilId
                        && t.Id == r.TarifaID
                        && r.Status == 1
                        select r).ToList();
            }
        }
        public static int IdPorNumeroHabitacion(int numeroHabitacion)
        {
            using (var db = new LobbyDB())
            {
                Reserva reserva = db.Reservas.Where(r => r.Habitacion.Numero == numeroHabitacion).FirstOrDefault();

                if (reserva != null)
                    return reserva.Id;
                else
                    return 0;
            }
        }
        public static void ModificarFechaLlegada(int _resvId, DateTime _fecha)
        {
            //TODO PROBAR SI FUNCIONA Y SE MODIFICA
            using (var db = new LobbyDB())
            {
                try
                {
                    Reserva res = TraerPorId(_resvId);
                    res.FechaLlegada = _fecha;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void ModificarFechaSalida(int _resvId, DateTime _fecha)
        {
            //Gabriel PROBAR SI FUNCIONA Y SE MODIFICA
            using (var db = new LobbyDB())
            {
                try
                {
                    Model.Reserva res = TraerPorId(_resvId);
                    res.FechaSalida = _fecha;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void Modificar(Reserva reserva)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Reserva reservaMod = db.Reservas.Where(r => r.Id == reserva.Id).FirstOrDefault();
                    reservaMod.Adultos = reserva.Adultos;
                    reservaMod.CamaExtra = reserva.CamaExtra;
                    reservaMod.Desayuno = reserva.Desayuno;
                    reservaMod.Extra = reserva.Extra;
                    reservaMod.FechaLlegada = reserva.FechaLlegada;
                    reservaMod.FechaSalida = reserva.FechaSalida;
                    reservaMod.HabitacionID = reserva.HabitacionID;
                    reservaMod.Ninios = reserva.Ninios;
                    reservaMod.Noches = reserva.Noches;
                    reservaMod.PerfilId = reserva.PerfilId;
                    reservaMod.Status = reserva.Status;
                    reservaMod.TarifaID = reserva.TarifaID;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void CambiarHabitacion(int resvId, int habitacionDesdeId, int habitacionHastaId)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Habitacion habitacionDesde = db.Habitaciones.Where(h => h.Id == habitacionDesdeId).FirstOrDefault();
                    Habitacion habitacionHasta = db.Habitaciones.Where(h => h.Id == habitacionHastaId).FirstOrDefault();
                    Reserva reserva = db.Reservas.Where(r => r.Id == resvId).FirstOrDefault();

                    habitacionDesde.Ocupada = false;
                    habitacionHasta.Ocupada = true;
                    reserva.HabitacionID = habitacionHastaId;
                    db.SaveChanges();
                    logger.Info("Cambio de habitación: " + habitacionDesde + " -> " + habitacionHasta);
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static int Crear(Reserva reserva)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Reservas.Add(reserva);
                    db.SaveChanges();
                    logger.Info("Crea reserva: " + reserva.Id);
                    return (from r in db.Reservas
                            orderby r.Id descending
                            select r.Id).First();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static void Cancelar(int resvId)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Reserva reserva = db.Reservas.Where(r => r.Id == resvId).FirstOrDefault();
                    reserva.Status = -1;

                    ReservaNoche reservaNoches = db.ReservasNoches.Where(rn => rn.ResvId == resvId).FirstOrDefault();
                    if(reservaNoches != null)
                        reservaNoches.Status = -1;

                    db.SaveChanges();
                    logger.Info("Cancela reserva: " + reserva.Id);
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
