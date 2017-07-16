using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("TiposDocumento")]
    public class TipoDocumento
    {
        [Key]
        public int Id { get; set; }
        [StringLength(15, ErrorMessage = "El campo DESCRIPCION no puede tener más de 15 caracteres")]
        public string Descripcion { get; set; }
    }
}
