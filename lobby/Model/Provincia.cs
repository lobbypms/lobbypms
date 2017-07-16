using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Provincias")]
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "El campo DESCRIPCION no puede tener más de 50 caracteres")]
        public string Descripcion { get; set; }
    }
}
