using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace PP.Dominio.MetaData
{
    public interface IEvento
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_Evento_Nombre", IsUnique = true)]
        string Nombre { get; set; }

        string Imagen { get; set; }

        [NotMapped]
        HttpPostedFileBase ImagenFile { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(400, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_Evento_Email", IsUnique = true)]
        string Email { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string NombreOrganizador { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(200, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string ApellidoOrganizador { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(400, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string InformacionAdicional { get; set; }
        
        [StringLength(300, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Facebook { get; set; }
        
        [StringLength(300, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        string Twitter { get; set; }

        bool Eliminado { get; set; }
    }
}
