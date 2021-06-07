using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Provincias")]
    [MetadataType(typeof(IProvincia))]
    public class Provincia : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long PaisId { get; set; }
        
        //================ Propiedades de Navegacion

        public virtual Pais Pais { get; set; }

        public ICollection<Localidad> Localidad { get; set; }
    }
}
