using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("RangosFiscales")]
    public class RangoFiscal
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [StringLength(4, ErrorMessage = "El campo SERIE no puede tener más de 4 caracteres")]
        [Key]
        [Column(Order = 2)]
        public string Serie { get; set; }
        public int PrimerNumero { get; set; }
        public int UltimoNumero { get; set; }
        public int NumeroActual { get; set; }
    }
}
