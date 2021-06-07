using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Pais")]
    [MetadataType(typeof(IPais))]
    public class Pais : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        //=============== Propiedades de Navegacion

        public ICollection<Provincia> Provincias { get; set; }
    }
}
