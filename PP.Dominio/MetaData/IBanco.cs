using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IBanco
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_Banco_Descripcion")]
        string Descripcion { get; set; }

        bool Eliminado { get; set; }
    }
}
