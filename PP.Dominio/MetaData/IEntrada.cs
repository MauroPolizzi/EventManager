using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Enum;

namespace PP.Dominio.MetaData
{
    public interface IEntrada
    {
        [Required(AllowEmptyStrings = true,ErrorMessage = "El campo es obligatorio")]
        [StringLength(250,ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        //[Index("Index_Entrada_NombreEntrada",IsUnique = false)]
        string NombreEntrada { get; set; }
        
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        //[Index("Index_Entrada_Descripcion", IsUnique = false)]
        string Descripcion { get; set; }

        //[Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        //[StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        //[Index("Index_Entrada_TipoEntrada", IsUnique = false)]
        //TipoEntrada TipoEntrada { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        //[Index("Index_Entrada_MinimoPermitido", IsUnique = false)]
        int MinimoPermitido{ get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        //[Index("Index_Entrada_MaximoPermitido", IsUnique = false)]
        int MaximoPermitido { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        long EventoId { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        decimal Precio { get; set; }
    }
}
