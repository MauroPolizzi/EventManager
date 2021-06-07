using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IFP_Transferencia
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        int NumeroCuenta { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        int NumeroCuentaReceptora { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        string Propietario { get; set; }

        long BancoId { get; set; }
    }
}
