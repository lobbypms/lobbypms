using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("ReservasNoches")]
    public class ReservaNoche
    {
        [Key]
        public int Id { get; set; }
        public int ResvId { get; set; }
        public Reserva Reserva { get; set; }
        public DateTime Fecha { get; set; }
        public int Status { get; set; }
        public decimal RoomRevenue { get; set; }
    }
}
