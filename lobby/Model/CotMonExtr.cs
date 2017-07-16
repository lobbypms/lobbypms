using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("CotMonExtr")]
    public class CotMonExtr
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public decimal Cotizacion { get; set; }
    }
}
