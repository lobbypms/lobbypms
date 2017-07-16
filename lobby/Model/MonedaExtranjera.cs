using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lobby.Model
{
    public class MonedaExtranjera
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "El campo DESCRIPCION no puede tener más de 50 caracteres")]
        public string Descripcion { get; set; }
    }
}
