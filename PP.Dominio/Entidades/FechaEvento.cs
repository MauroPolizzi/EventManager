using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("FechaEvento")]
    [MetadataType(typeof(IFechaEvento))]
    public class FechaEvento :EntityBase
    {
        public TimeSpan HoraDesde { get; set; }

        public TimeSpan HoraHasta { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public long EventoId { get; set; }

        public bool Eliminado { get; set; }

        //============ Propiedades de navegacion

        //public virtual Evento Evento { get; set; }
    }
}
