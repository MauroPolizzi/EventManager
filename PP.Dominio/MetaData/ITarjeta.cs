using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface ITarjeta
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(20, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_Tarjeta_Codigo", IsUnique = true)]
        string Codigo { get; set; }

        string Descripcion { get; set; }

        bool Eliminado { get; set; }

    }
}
