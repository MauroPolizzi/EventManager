using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IUsuario
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_Usuario_NombreUsuario", IsUnique = true)]
        string NombreUsuario { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        string Password { get; set; }

        bool EstaBloqueado { get; set; }

        long ClienteId { get; set; }
    }
}
