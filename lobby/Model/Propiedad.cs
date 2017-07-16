using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lobby.Model
{
    public class Propiedad
    {
        [Key]
        [StringLength(50, ErrorMessage = "El campo NOMBRE no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }
        [StringLength(100, ErrorMessage = "El campo DIRECCION no puede tener más de 100 caracteres")]
        public string Direccion { get; set; }
        [StringLength(50, ErrorMessage = "El campo CIUDAD no puede tener más de 50 caracteres")]
        public string Ciudad { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        [StringLength(20, ErrorMessage = "El campo TELEFONO no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }
        [StringLength(50, ErrorMessage = "El campo EMAIL no puede tener más de 50 caracteres")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "El campo RESPONSABLE no puede tener más de 50 caracteres")]
        public string Responsable { get; set; }
        [StringLength(256, ErrorMessage = "El campo EXTRA no puede tener más de 256 caracteres")]
        public string Extra { get; set; }
    }
}
