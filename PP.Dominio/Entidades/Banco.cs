using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("Banco")]
    [MetadataType(typeof(IBanco))]
    public class Banco : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegacion
        public virtual ICollection<FP_Transferencia> FpTransferencias { get; set; }
    }
}
