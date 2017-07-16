using System.Collections.Generic;
using System.Linq;
using lobby.Model;
using log4net;
using System.Reflection;

namespace lobby.Admin
{
    public class AdminUsuarios
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Methods
        public static List<Usuario> TraerTodos()
        {
            using (var db = new LobbyDB())
            {
                return db.Usuarios.ToList();
            }
        }
        public static Usuario TraerPorUsername(string username)
        {
            using (var db = new LobbyDB())
            {
                return db.Usuarios.Where(u => u.Username == username).FirstOrDefault();
            }
        }
        public static void Crear(Usuario usuario)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    logger.Info("Crea usuario: " + usuario.Id);
                }
                catch (System.Exception e)
                {
                    logger.Fatal(e.InnerException.Message);
                }
            }
        }
        public static void Modificar(Usuario usuario)
        {
            using (var db = new LobbyDB())
            {
                try
                {
                    Usuario usuarioMod = db.Usuarios.Where(u => u.Username == usuario.Username).FirstOrDefault();

                    usuarioMod.Nombre = usuario.Nombre;
                    usuarioMod.Apellido = usuario.Apellido;
                    usuarioMod.Administrador = usuario.Administrador;
                    usuarioMod.Bloqueado = usuario.Bloqueado;
                    usuarioMod.Password = usuario.Password;
                    usuarioMod.Username = usuario.Username;

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
