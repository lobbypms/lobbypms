using System.Collections.Generic;
using System.Linq;
using lobby.Model;

namespace lobby.Admin
{
    public class AdminUsuarios
    {
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
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }
        public static void Modificar(Usuario usuario)
        {
            using (var db = new LobbyDB())
            {
                Usuario usuarioMod = db.Usuarios.Where(u => u.Username == usuario.Username).Single();

                usuarioMod.Nombre = usuario.Nombre;
                usuarioMod.Apellido = usuario.Apellido;
                usuarioMod.Administrador = usuario.Administrador;
                usuarioMod.Bloqueado = usuario.Bloqueado;
                usuarioMod.Password = usuario.Password;
                usuarioMod.Username = usuario.Username;

                db.SaveChanges();
            }
        }
        #endregion
    }
}
