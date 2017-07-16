using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Transacciones")]
    public class Transaccion
    {
        [Key]
        public int NumTransaccion { get; set; }
        public int NumDocumento { get; set; }
        public Factura Factura { get; set; }
        [StringLength(3, ErrorMessage = "El campo SERIE no puede tener más de 3 caracteres")]
        public string Serie { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal MontoBruto { get; set; }
        public decimal IVA { get; set; }
        public int ctSubgrupoId { get; set; }
        public ctSubgrupo ctSubgrupo { get; set; }
        public int CodTransaccionId { get; set; }
        public CodigoTransaccion CodigoTransaccion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public int ResvId { get; set; }
        public Reserva Reserva { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [StringLength(256, ErrorMessage = "El campo EXTRA no puede tener más de 3 caracteres")]
        public string Extra { get; set; }
    }
}
