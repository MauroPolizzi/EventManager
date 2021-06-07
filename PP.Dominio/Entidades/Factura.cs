using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Factura")]
    [MetadataType(typeof(IFactura))]
    public class Factura : EntityBase
    {
        public int NumeroFactura { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadEntrada { get; set; }

        public decimal Monto { get; set; }

        public long UsuarioId { get; set; }

        public long EntradaId { get; set; }

        //public long FormaPagoId { get; set; }

        public bool Eliminado { get; set; }

        //============== Propiedades de navegacion
        //public ICollection<FormaPago> FormaPagos { get; set; }

        public virtual Entrada Entrada { get; set; }

        public virtual Usuario Usuario { get; set; }

        public ICollection<Detalle> Detalles { get; set; }
    }
}
