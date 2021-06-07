using System;
using PP.Dominio.Enum;
using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.FormaPago
{
    public class FormaPagoDto : DtoBase
    {
        public DateTime Fecha { get; set; }

        public decimal Monto { get; set; }

        public long EntradaId { get; set; }

        public TipoFormaPago TipoFormaPago { get; set; }
    }
}
