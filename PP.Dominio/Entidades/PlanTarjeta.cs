using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("PlanTarjeta")]
    [MetadataType(typeof(IPlanTarjeta))]
    public class PlanTarjeta : EntityBase
    {
        public long TarjetaId { get; set; }

        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public bool Eliminado { get; set; }

        public decimal Interes { get; set; }
        
        // Propiedades de navegacion

        public virtual Tarjeta Tarjeta { get; set; }

        //public ICollection<FP_Tarjeta> FP_Tarjetas { get; set; }
    }
}
