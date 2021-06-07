using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IFP_Tarjeta
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        //[StringLength(20, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_FPTarjeta_FP_Tarjeta", IsUnique = true)]
        int NumeroTarjeta { get; set; }

        long PlanTarjetaId { get; set; }
    }
}
