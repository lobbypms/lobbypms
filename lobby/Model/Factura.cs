using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Facturas")]
    public class Factura
    {
        public DateTime FechaDoc { get; set; }
        [Key]
        [Column(Order = 1)]
        public int NumeroDoc { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Serie { get; set; }
        public RangoFiscal RangosFiscal { get; set; }
        public int? ResvId { get; set; }
        public Reserva Reserva { get; set; }
        public decimal? TotalNeto { get; set; }
        public decimal? TotalBruto { get; set; }
        public decimal? TotalIVA { get; set; }
        public int? Status { get; set; }
    }
}
