using lobby.Model;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lobby.Admin
{
    public static class AdminPropiedad
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static Propiedad Traer()
        {
            using (var db = new LobbyDB())
            {
                return db.Propiedad.FirstOrDefault();
            }
        }
        public static void Grabar(Propiedad propiedad)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Propiedad propiedadMod = db.Propiedad.Where(p => p.Nombre == p.Nombre).FirstOrDefault();
                    propiedadMod.Ciudad = propiedad.Ciudad;
                    propiedadMod.Direccion = propiedad.Direccion;
                    propiedadMod.Email = propiedad.Email;
                    propiedadMod.Extra = propiedad.Extra;
                    propiedadMod.Nombre = propiedad.Nombre;
                    propiedadMod.PaisId = propiedad.PaisId;
                    propiedadMod.Responsable = propiedad.Responsable;
                    propiedadMod.Telefono = propiedad.Telefono;
                    db.SaveChanges();
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }

            }
        }
    }
}
