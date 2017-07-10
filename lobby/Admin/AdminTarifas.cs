using lobby.Model;
using System.Collections.Generic;
using System.Linq;

namespace lobby.Admin
{
    public static class AdminTarifas
    {
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
                return db.Tarifas.Where(t => t.Id == id).Single();
            }
        }
        public static Tarifa TraerPorCodigo(string codigo)
        {
            using (var db = new LobbyDB())
            {
                return db.Tarifas.Where(t => t.Codigo == codigo).Single();
            }
        }
        public static int Crear(Tarifa tarifa)
        {
            using (var db = new LobbyDB())
            {
                db.Tarifas.Add(tarifa);
                db.SaveChanges();
                return (from t in db.Tarifas
                        orderby t.Id descending
                        select t.Id).First();
            }
        }
        public static void Modificar(Tarifa tarifa)
        {
            using (var db = new LobbyDB())
            {
                Tarifa tarifaMod = db.Tarifas.Where(t => t.Codigo == tarifa.Codigo).Single();
                tarifaMod.Codigo = tarifa.Codigo;
                tarifaMod.Descripcion = tarifa.Descripcion;
                tarifaMod.Monto = tarifa.Monto;
                tarifaMod.Nombre = tarifa.Nombre;

                db.SaveChanges();
            }
        }
        #endregion
    }
}
