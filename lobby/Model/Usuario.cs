using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Index(IsUnique = true)]
        [StringLength(15, ErrorMessage = "El nombre de usuario no puede tener más de 15 caracteres")]
        public string Username { get; set; }
        public bool Bloqueado { get; set; }
        public bool Administrador { get; set; }
        public string Password { get; set; }
        public bool ActualizarPassword { get; set; }
    }
}
