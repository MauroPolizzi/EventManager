using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Tarjeta")]
    [MetadataType(typeof(ITarjeta))]
    public class Tarjeta : EntityBase
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegacion
        
        public virtual ICollection<PlanTarjeta> PlanTarjetas { get; set; }
    }
}
