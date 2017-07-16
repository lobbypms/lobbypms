using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Perfiles")]
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [StringLength(20, ErrorMessage = "El campo NUMERODOCUMENTO no puede tener más de 20 caracteres")]
        public string NumeroDocumento { get; set; }
        [StringLength(25, ErrorMessage = "El campo APELLIDO no puede tener más de 25 caracteres")]
        public string Apellido { get; set; }
        [StringLength(25, ErrorMessage = "El campo NOMBRE no puede tener más de 25 caracteres")]
        public string Nombre { get; set; }
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(25, ErrorMessage = "El campo NUMEROTARJETA no puede tener más de 25 caracteres")]
        public string NumeroTarjeta { get; set; }
        [StringLength(256, ErrorMessage = "El campo EXTRA no puede tener más de 256 caracteres")]
        public string Extra { get; set; }
        [StringLength(50, ErrorMessage = "El campo EMAIL no puede tener más de 50 caracteres")]
        public string Email { get; set; }
        public bool? Estacionamiento { get; set; }
        public int? PatenteId { get; set; }
        public Patente Patente { get; set; }
    }
}
