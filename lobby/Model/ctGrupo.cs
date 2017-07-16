using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("ctGrupos")]
    public class ctGrupo
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(5, ErrorMessage = "El campo CODIGO no puede tener más de 5 caracteres")]
        public string Codigo { get; set; }
        [StringLength(25, ErrorMessage = "El campo DESCRIPCION no puede tener más de 25 caracteres")]
        public string Descripcion { get; set; }
        public List<ctSubgrupo> ctSubgrupos { get; set; }
    }
}
