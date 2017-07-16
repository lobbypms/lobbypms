using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("FormasPago")]
    public class FormaPago
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25, ErrorMessage = "El campo DESCRIPCION no puede tener más de 25 caracteres")]
        public string Descripcion { get; set; }
        public bool Credito { get; set; }
    }
}
