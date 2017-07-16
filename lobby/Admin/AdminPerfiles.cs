using lobby.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lobby.Admin
{
    public static class AdminPerfiles
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<Perfil> TraerTodos()
        {
            using (var db = new LobbyDB())
            {
                return db.Perfiles.ToList();
            }
        }
        public static Perfil TraerPorDocumento(string documento)
        {
            using (var db = new LobbyDB())
            {
                return db.Perfiles.Where(p => p.NumeroDocumento == documento).FirstOrDefault();
            }
        }
        public static Perfil TraerPorIdReserva(int resvId)
        {
            using (var db = new LobbyDB())
            {
                return (from r in db.Reservas
                        join p in db.Perfiles on r.PerfilId equals p.Id
                        where r.Id == resvId
                        select p).FirstOrDefault();
            }
        }
        public static Perfil TraerPorId(int id)
        {
            using (var db = new LobbyDB())
            {
                return db.Perfiles.Where(p => p.Id == id).FirstOrDefault();
            }
        }
        public static List<Perfil> TraerPorDocumentoOApellido(string documento, string apellido)
        {
            using (var db = new LobbyDB())
            {
                return db.Perfiles.Where(p => p.NumeroDocumento == documento || p.Apellido.Contains(apellido)).ToList();
            }
        }
        public static void Modificar(Perfil perfil)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Perfil perfilMod = db.Perfiles.Where(p => p.Id == perfil.Id).FirstOrDefault();

                    perfilMod.Apellido = perfil.Apellido;
                    perfilMod.DireccionId = perfil.DireccionId;
                    perfilMod.DocumentoId = perfil.DocumentoId;
                    perfilMod.Email = perfil.Email;
                    perfilMod.Estacionamiento = perfil.Estacionamiento;
                    perfilMod.Extra = perfil.Extra;
                    perfilMod.FechaNacimiento = perfil.FechaNacimiento;
                    perfilMod.Nombre = perfil.Nombre;
                    perfilMod.NumeroDocumento = perfil.NumeroDocumento;
                    perfilMod.NumeroTarjeta = perfil.NumeroTarjeta;
                    perfilMod.PatenteId = perfil.PatenteId;

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static int Crear(Perfil perfil)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Perfiles.Add(perfil);
                    db.SaveChanges();

                    logger.Info("Agrega perfil: " + perfil.Id);

                    return (from p in db.Perfiles
                            orderby p.Id descending
                            select p.Id).First();
                }
                catch (Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                    return 0;
                }
            }
        }
        #endregion
    }
}
