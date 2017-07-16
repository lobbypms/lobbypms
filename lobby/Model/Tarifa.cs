using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Tarifas")]
    public class Tarifa
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        [StringLength(5, ErrorMessage = "El campo CODIGO no puede tener más de 5 caracteres")]
        public string Codigo { get; set; }
        [StringLength(256, ErrorMessage = "El campo DESCRIPCION no puede tener más de 256 caracteres")]
        public string Descripcion { get; set; }
    }
}
