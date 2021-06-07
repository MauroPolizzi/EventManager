using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Localidad")]
    [MetadataType(typeof(ILocalidad))]
    public class Localidad : EntityBase
    {
        public string Descripcion { get; set; }

        public int CodigoPostal { get; set; }

        public long ProvinciaId { get; set; }

        public bool Eliminado { get; set; }

        //============ Propiedades de navegacion

        public virtual Provincia Provincia { get; set; }

        public ICollection<Ubicacion> Ubicacions { get; set; }
    }
}
