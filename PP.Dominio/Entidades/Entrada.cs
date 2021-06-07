using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.Enum;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Entrada")]
    [MetadataType(typeof(IEntrada))]
    public class Entrada :EntityBase
    {
        public TipoEntrada TipoEntrada { get; set; }

        public string NombreEntrada { get; set; }

        public int CantidadDisponible { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public int MaximoPermitido { get; set; }

        public int MinimoPermitido { get; set; }

        public long EventoId { get; set; }

        //public long FacturaId { get; set; }

        public bool Eliminado { get; set; }

        //=========== Propiedades de navegacion

        public virtual Evento Evento { get; set; }

        public ICollection< Factura> Facturas { get; set; }
    }
}
