using System.ComponentModel.DataAnnotations;

namespace PP.Dominio.MetaData
{
    public interface IPreguntaFrecuente
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(400, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(400, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Respuesta { get; set; }

        bool Eliminado { get; set; }
    }
}
