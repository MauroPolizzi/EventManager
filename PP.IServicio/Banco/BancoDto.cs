using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Banco
{
    public class BancoDto : DtoBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}
