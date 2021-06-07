using System;
using System.ComponentModel.DataAnnotations;
using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.FechaEvento
{
    public class FechaEventoDto: DtoBase
    {
        [DataType(DataType.Time)]
        public TimeSpan HoraDesde { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HoraHasta { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaHasta { get; set; }

        public long EventoId { get; set; }

        public bool Eliminado { get; set; }
    }
}
