using PP.Dominio.Base;
using PP.Dominio.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.Entidades
{
    [Table("Configuracion")]
    [MetadataType(typeof(IConfiguracion))]
    public class Configuracion : EntityBase
    {
        //Propiedades

        public bool Publica { get; set; }

        public bool MostrarCantidadEntradas { get; set; }

        //Propiedades de Navegacion 

        //public virtual Evento Evento { get; set; }
    }
}
