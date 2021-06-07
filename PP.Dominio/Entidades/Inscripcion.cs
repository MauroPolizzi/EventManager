using PP.Dominio.Base;
using PP.Dominio.MetaData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.Entidades
{
    [Table("Inscripcion")]
    [MetadataType(typeof(IInscripcion))]
    public class Inscripcion : EntityBase
    {
        //Propiedades
        public DateTime TiempoInscripcion { get; set; }

        public long ClienteId { get; set; }

        public long EventoId { get; set; }

        public bool Eliminado { get; set; }

        //Propiedades de navegacion

        public virtual Evento Evento { get; set; }

        public virtual ClientePagina ClientePagina { get; set; }
    }
}
