using PP.Dominio.Base;
using PP.Dominio.MetaData;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace PP.Dominio.Entidades
{
    [Table("Evento")]
    [MetadataType(typeof(IEvento))]
    public class Evento : EntityBase
    {
        //Propiedades
        public string Nombre { get; set; }

        public string Imagen { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImagenFile { get; set; }

        public string Descripcion { get; set; }

        public string Email { get; set; }

        public string NombreOrganizador { get; set; }

        public string ApellidoOrganizador { get; set; }

        public string InformacionAdicional { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public bool Eliminado { get; set; }

        public long TipoEventoId { get; set; }

        //Propiedades de navegacion

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }

        public virtual Configuracion Configuracion { get; set; }

        public virtual TipoEvento TipoEvento { get; set; }

        public virtual ICollection<PreguntaFrecuente> PreguntaFrecuentes { get; set; }

        public virtual ICollection<Entrada> Entradas { get; set; }

        public virtual FechaEvento FechaEvento { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }

        //public virtual TemaEvento TemaEvento { get; set; }
    }
}
