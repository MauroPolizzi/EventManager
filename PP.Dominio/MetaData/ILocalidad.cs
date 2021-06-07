using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface ILocalidad
    {
        [Required(AllowEmptyStrings = true,ErrorMessage = "El campo es Obligatorio.")]
        [StringLength(100,ErrorMessage = "El campo {0} no debe pasar de los {1} caracteres.")]
        //[Index("Index_Localidad_Descripcion")]
        string Descripcion { get; set; }

        //[Index("Index_Localidad_CodigoPostal",IsUnique = true)]
        int CodigoPostal { get; set; }
        
        [Required(AllowEmptyStrings =  true)]
        long ProvinciaId { get; set; }
    }
}
