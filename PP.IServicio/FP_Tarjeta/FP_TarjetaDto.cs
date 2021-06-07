using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.FP_Tarjeta
{
    public class FP_TarjetaDto : DtoBase
    {
        public int NumeroTarjeta { get; set; }

        public long PlanTarjetaId { get; set; }
    }
}
