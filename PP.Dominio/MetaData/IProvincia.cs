using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IProvincia
    {
        [Required(AllowEmptyStrings = true,ErrorMessage = "El campo es Obligatorio.")]
        [StringLength(100,ErrorMessage = "El campo {0} no debe pasar de {1} caracteres.")]
        //[Index("Index_Provincia_Descripcion",IsUnique = true)]
        string Descripcion { get; set; }

        bool Eliminado { get; set; }
    }
}
