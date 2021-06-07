using PP.Servicio.Base.DtoBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace PP.IServicio.Inscripcion
{
    public class InscripcionDto : DtoBase
    {
        [Display(Name = "TiempoInscripcion")]
        [DataType(DataType.DateTime)]
        public DateTime TiempoInscripcion { get; set; }

        public long ClienteId { get; set; }
        
        public long EventoId { get; set; }

        public bool Eliminado { get; set; }
    }
}
