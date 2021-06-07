using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("ClientePagina")]
    [MetadataType(typeof(IClientePagina))]
    public class ClientePagina : EntityBase
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Domicilio { get; set; }

        public string Email { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegacion

        public virtual ICollection<Factura> Facturas { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
        
        //public virtual Usuario Usuario { get; set; }
    }
}
