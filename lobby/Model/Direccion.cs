using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("Direcciones")]
    public class Direccion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "El campo CALLE no puede tener más de 50 caracteres")]
        public string Calle { get; set; }
        public int? Numero { get; set; }
        [StringLength(5, ErrorMessage = "El campo PISO no puede tener más de 5 caracteres")]
        public string Piso { get; set; }
        [StringLength(5, ErrorMessage = "El campo DEPARTAMENTO no puede tener más de 5 caracteres")]
        public string Departamento { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        [StringLength(50, ErrorMessage = "El campo LOCALIDAD no puede tener más de 50 caracteres")]
        public string Localidad { get; set; }
        public int? CodigoPostal { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
    }
}
