using lobby.Model;
using log4net;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminDirecciones
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static int Crear(Direccion direccion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Direcciones.Add(direccion);
                    db.SaveChanges();
                    logger.Info("Agrega Direccion: " + direccion.Id);
                    return (from p in db.Direcciones
                            orderby p.Id descending
                            select p.Id).First();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        public static Direccion TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.Direcciones.Where(d => d.Id == id).FirstOrDefault();
            }
        }
        public static void Modificar(Direccion direccion)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Direccion direccionMod = db.Direcciones.Where(d => d.Id == direccion.Id).FirstOrDefault();

                    direccionMod.Calle = direccion.Calle;
                    direccionMod.CodigoPostal = direccion.CodigoPostal;
                    direccionMod.Departamento = direccion.Departamento;
                    direccionMod.Localidad = direccion.Localidad;
                    direccionMod.Numero = direccion.Numero;
                    direccionMod.PaisId = direccion.PaisId;
                    direccionMod.Piso = direccion.Piso;
                    direccionMod.ProvinciaId = direccion.ProvinciaId;

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
