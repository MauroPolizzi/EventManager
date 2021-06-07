using System;
using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Factura
{
    public class FacturaDto: DtoBase
    {
        public int NumeroFactura { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadEntrada { get; set; }

        public decimal PrecioEntrada { get; set; }

        public decimal Monto { get; set; }

        public long ClienteId { get; set; }

        public long EntradaId { get; set; }
        

        public bool Eliminado { get; set; }

        //=============== Cliente =================//
        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }
}
