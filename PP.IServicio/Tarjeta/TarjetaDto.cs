using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Tarjeta
{
    public class TarjetaDto : DtoBase
    {
        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public bool Eliminado { get; set; }
    }
}
