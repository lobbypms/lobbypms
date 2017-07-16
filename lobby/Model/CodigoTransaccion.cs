using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lobby.Model
{
    [Table("CodigosTransaccion")]
    public class CodigoTransaccion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(5, ErrorMessage = "El campo CODIGO no puede tener más de 5 caracteres")]
        public string Codigo { get; set; }
        public int GrupoId { get; set; }
        public ctGrupo ctGrupo { get; set; }
        public int SubgrupoId { get; set; }
        public ctSubgrupo ctSubgrupo { get; set; }
        public bool GenIVA { get; set; }
        [StringLength(25, ErrorMessage = "El campo DESCRIPCION no puede tener más de 25 caracteres")]
        public string Descripcion { get; set; }
        [StringLength(1, ErrorMessage = "El campo TIPO no puede tener más de 1 caracteres")]
        public string Tipo { get; set; }
    }
}
