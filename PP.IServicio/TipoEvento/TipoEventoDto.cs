using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.TipoEvento
{
    public class TipoEventoDto : DtoBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}
