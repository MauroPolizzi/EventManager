using PP.Dominio.Base;
using PP.Dominio.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.Entidades
{
    [Table("TipoEvento")]
    [MetadataType(typeof(ITipoEvento))]
    public class TipoEvento : EntityBase
    {
        //Propiedades
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        //Propiedades de navegacion
        //public virtual Evento Evento { get; set; }
    }
}
