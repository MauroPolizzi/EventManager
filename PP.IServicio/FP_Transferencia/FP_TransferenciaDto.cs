using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.FP_Transferencia
{
    public class FP_TransferenciaDto : DtoBase
    {
        public int NumeroCuenta { get; set; }

        public int NumeroCuentaReceptora { get; set; }

        public string Propietario { get; set; }

        public long BancoId { get; set; }
    }
}
