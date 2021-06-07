using PP.Dominio.Base;
using PP.Dominio.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.Entidades
{
    [Table("PreguntaFrecuente")]
    [MetadataType(typeof(IPreguntaFrecuente))]
    public class PreguntaFrecuente : EntityBase
    {
        //Propiedades
        public string Descripcion { get; set; }

        public string Respuesta { get; set; }

        public bool Eliminado { get; set; }

        public long EventoId { get; set; }
        //Propiedades de Navegacion

        public virtual Evento Evento { get; set; }
    }
}
