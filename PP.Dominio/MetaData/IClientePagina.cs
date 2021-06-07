using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface IClientePagina
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_ClientePagina_Nombre", IsUnique = true)]
        string Nombre { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_ClientePagina_Apellido", IsUnique = true)]
        string Apellido { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(15, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Telefono { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(15, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Celular { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Domicilio { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_ClientePagina_Email", IsUnique = true)]
        string Email { get; set; }
    }
}
