using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Usuario")]
    [MetadataType(typeof(IUsuario))]
    public class Usuario : EntityBase
    {
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public long ClienteId { get; set; }

        // Propiedades de navegacion

        public virtual ClientePagina ClientePagina { get; set; }
    }
}
