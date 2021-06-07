using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.PreguntaFrecuente
{
    public class PreguntaFrecuenteDto : DtoBase
    {
        public string Descripcion { get; set; }

        public string Respuesta { get; set; }

        public bool Eliminado { get; set; }

        public long EventoId { get; set; }

        public string EventoDescripcion { get; set; }

    }
}
