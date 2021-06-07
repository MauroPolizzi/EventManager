using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Detalle
{
    public class DetalleDto : DtoBase
    {
        public decimal Costo { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public long FacturaId { get; set; }
    }
}
