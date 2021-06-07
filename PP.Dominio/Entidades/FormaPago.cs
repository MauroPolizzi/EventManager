using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.Enum;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("FormaPago")]
    [MetadataType(typeof(IFormaPago))]
    public class FormaPago : EntityBase
    {
        //public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public long FaturaId { get; set; }

        public TipoFormaPago TipoFormaPago { get; set; }

        // Propiedades de navegacion
        public virtual Factura Factura { get; set; }
    }
}
