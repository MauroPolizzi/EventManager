using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("FP_Tarjeta")]
    [MetadataType(typeof(IFP_Tarjeta))]
    public class FP_Tarjeta : FormaPago
    {
        public int NumeroTarjeta { get; set; }

        public long PlanTarjetaId { get; set; }

        // Porpiedades de navegacion
        public virtual PlanTarjeta PlanTarjeta { get; set; }
    }
}
