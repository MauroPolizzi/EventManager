using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Detalle")]
    [MetadataType(typeof(IDetalle))]
    public class Detalle : EntityBase
    {
        public decimal Costo { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public long FacturaId { get; set; }

        //=============== Propiedades de navegacion

        public virtual Factura Factura { get; set; }
    }
}
