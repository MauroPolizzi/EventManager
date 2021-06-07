using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Dominio.Base;
using PP.Dominio.MetaData;

namespace PP.Dominio.Entidades
{
    [Table("FP_Transferencia")]
    [MetadataType(typeof(IFP_Transferencia))]
    public class FP_Transferencia : FormaPago
    {
        public int NumeroCuenta { get; set; }

        public int NumeroCuentaReceptora { get; set; }

        public string Propietario { get; set; }

        public long BancoId { get; set; }

        // Propiedades de navegacion
        //public virtual FormaPago FormaPago { get; set; }

        public virtual Banco Banco { get; set; }
    }
}
