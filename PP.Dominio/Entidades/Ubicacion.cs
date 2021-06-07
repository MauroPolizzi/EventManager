using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Ubicacion")]
    [MetadataType(typeof(IUbicacion))]
    public class Ubicacion : EntityBase
    {
        public string NombreEstablecimiento { get; set; }

        public string PrimDireccion { get; set; }

        public string SegDireccion { get; set; }

        public long EventoId { get; set; }

        public long LocalidadId { get; set; }

        public bool Eliminado { get; set; }

        //=========== Propiedades de navegacio

        //public virtual Evento Evento { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
