using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public int? HabitacionID { get; set; }
        public Habitacion Habitacion { get; set; }
        public int TarifaID { get; set; }
        public Tarifa Tarifa { get; set; }
        public int Noches { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Adultos { get; set; }
        public int Ninios { get; set; }
        public bool CamaExtra { get; set; }
        public bool Desayuno { get; set; }
        [StringLength(256, ErrorMessage = "El campo EXTRA no puede tener más de 256 caracteres")]
        public string Extra { get; set; }
        public int? Status { get; set; }
    }
}
