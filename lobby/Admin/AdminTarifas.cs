using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminTarifas
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<Tarifa> TraerTodas()
        {
            using (var db = new LobbyDB())
            {
                return db.Tarifas.ToList();
            }
        }
        public static Tarifa TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.Tarifas.Where(t => t.Id == id).FirstOrDefault();
            }
        }
        public static Tarifa TraerPorCodigo(string codigo)
        {
            using (var db = new LobbyDB())
            {
                return db.Tarifas.Where(t => t.Codigo == codigo).FirstOrDefault();
            }
        }
        public static int Crear(Tarifa tarifa)
        {
            using (var db = new LobbyDB())
            {

                try
                {
                    db.Tarifas.Add(tarifa);
                    db.SaveChanges();
                    logger.Info("Crea tarifa: " + tarifa.Id);
                    return (from t in db.Tarifas
                            orderby t.Id descending
                            select t.Id).First();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static void Modificar(Tarifa tarifa)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Tarifa tarifaMod = db.Tarifas.Where(t => t.Codigo == tarifa.Codigo).FirstOrDefault();
                    tarifaMod.Codigo = tarifa.Codigo;
                    tarifaMod.Descripcion = tarifa.Descripcion;
                    tarifaMod.Monto = tarifa.Monto;
                    tarifaMod.Nombre = tarifa.Nombre;

                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        #endregion
    }
}
