using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.PlanTarjeta
{
    public class PlanTarjetaDto : DtoBase
    {
        public long TarjetaId { get; set; }

        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public bool Eliminado { get; set; }

        public decimal Interes { get; set; }
    }
}
