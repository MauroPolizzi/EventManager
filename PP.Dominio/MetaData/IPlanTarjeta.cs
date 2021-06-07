using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IPlanTarjeta
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(20, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_PlanTarjeta_Codigo", IsUnique = true)]
        string Codigo { get; set; }

        long TarjetaId { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Descripcion { get; set; }

        bool Eliminado { get; set; }

        //[Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        //[StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        decimal Interes { get; set; }
    }
}
