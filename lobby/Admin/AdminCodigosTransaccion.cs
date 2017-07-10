using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminCodigosTransaccion
    {
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
                return db.CodigosTransacciones.Where(c => c.Id == id).Single();
            }
        }
        public static CodigoTransaccion TraerPorCodigo(string codigo)
        {
            using (LobbyDB db = new LobbyDB())
            {
                return db.CodigosTransacciones.Where(c => c.Codigo == codigo).Single();
            }
        }
        public static void Agregar(CodigoTransaccion codigoTransaccion)
        {
            using (LobbyDB db = new LobbyDB())
            {
                db.CodigosTransacciones.Add(codigoTransaccion);
                db.SaveChanges();
            }
        }
        public static void Modificar(CodigoTransaccion codigoTransaccion)
        {
            using (LobbyDB db = new LobbyDB())
            {
                CodigoTransaccion codigoTransaccionMod = db.CodigosTransacciones.Where(c => c.Id == codigoTransaccion.Id).Single();
                codigoTransaccionMod.Descripcion = codigoTransaccion.Descripcion;
                codigoTransaccionMod.GenIVA = codigoTransaccion.GenIVA;
                codigoTransaccionMod.GrupoId = codigoTransaccion.GrupoId;
                codigoTransaccionMod.SubgrupoId = codigoTransaccion.SubgrupoId;
                codigoTransaccionMod.Tipo = codigoTransaccion.Tipo;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
