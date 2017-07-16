using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminCodigosTransaccion
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Methods
        public static List<CodigoTransaccion> TraerTodos()
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.CodigosTransacciones.ToList();
            }
        }
        public static CodigoTransaccion TraerPorId(int id)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.CodigosTransacciones.Where(c => c.Id == id).FirstOrDefault();
            }
        }
        public static CodigoTransaccion TraerPorCodigo(string codigo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.CodigosTransacciones.Where(c => c.Codigo == codigo).FirstOrDefault();
            }
        }
        public static void Agregar(CodigoTransaccion codigoTransaccion)
        {
            using (LobbyDB db = new LobbyDB())
            {
                try
                {
                    db.CodigosTransacciones.Add(codigoTransaccion);
                    db.SaveChanges();
                    logger.Info("Agrega código transacción: " + codigoTransaccion.Id);
                }
                catch (System.Exception ex)
                {
                    logger.Fatal(ex.InnerException.Message);
                }
            }
        }
        public static void Modificar(CodigoTransaccion codigoTransaccion)
        {
            using (LobbyDB db = new LobbyDB())
            {
                try
                {
                    CodigoTransaccion codigoTransaccionMod = db.CodigosTransacciones.Where(c => c.Id == codigoTransaccion.Id).FirstOrDefault();
                    codigoTransaccionMod.Descripcion = codigoTransaccion.Descripcion;
                    codigoTransaccionMod.GenIVA = codigoTransaccion.GenIVA;
                    codigoTransaccionMod.GrupoId = codigoTransaccion.GrupoId;
                    codigoTransaccionMod.SubgrupoId = codigoTransaccion.SubgrupoId;
                    codigoTransaccionMod.Tipo = codigoTransaccion.Tipo;
                    db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    logger.Fatal(ex.InnerException.Message);
                }
            }
        }
        #endregion
    }
}
