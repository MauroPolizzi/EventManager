using System;
using System.ComponentModel.DataAnnotations;

namespace PP.Dominio.MetaData
{
    public interface IInscripcion
    {
        [Display(Name = "TiempoInscripcion")]
        [DataType(DataType.DateTime)]
        DateTime TiempoInscripcion { get; set; }

        long ClienteId { get; set; }

        long EventoId { get; set; }
    }
}
