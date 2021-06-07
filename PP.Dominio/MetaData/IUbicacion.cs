using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IUbicacion
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es Obligatorio.")]
        [StringLength(100,ErrorMessage = "El campo {0} no debe pasar de {1} caracteres.")]
        //[Index("Index_Ubicacion_NombreEstablecimiento")]
        string NombreEstablecimiento { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe pasar de {1} caracteres.")]
        //[Index("Index_Ubicacion_PrimDireccion")]
        string PrimDireccion { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no debe pasar de {1} caracteres.")]
        //[Index("Index_Ubicacion_SegDireccion")]
        string SegDireccion { get; set; }

        [Required(AllowEmptyStrings = true)]
        long EventoId { get; set; }
long LocalidadId { get; set; }
    }
}
