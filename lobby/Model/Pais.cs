using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [StringLength(2, ErrorMessage = "El campo CODIGO no puede tener más de 2 caracteres")]
        public string Codigo { get; set; }
        [StringLength(50, ErrorMessage = "El campo DESCRIPCION no puede tener más de 50 caracteres")]
        public string Descripcion { get; set; }
    }
}
