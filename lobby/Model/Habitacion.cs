using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Habitaciones")]
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }
        public int TipoId { get; set; }
        public TipoHabitacion HabitacionTipo { get; set; }
        public int Numero { get; set; }
        public int? Piso { get; set; }
        [StringLength(100, ErrorMessage = "El campo DESCRIPCION no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; }
        public bool Bloqueada { get; set; }
        public bool Cabana { get; set; }
        public bool Ocupada { get; set; }
    }
}
