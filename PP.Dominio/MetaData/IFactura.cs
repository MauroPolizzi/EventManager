using System;
using System.ComponentModel.DataAnnotations;

namespace PP.Dominio.MetaData
{
    public interface IFactura
    {
        [Required(AllowEmptyStrings = true)]
        int NumeroFactura { get; set; }
        
        DateTime Fecha { get; set; }

        [Required(AllowEmptyStrings = true)]
        int CantidadEntrada { get; set; }

        [Required(AllowEmptyStrings = true)]
        decimal Monto { get; set; }

        [Required(AllowEmptyStrings = true)]
        long UsuarioId { get; set; }

        [Required(AllowEmptyStrings = true)]
        long EntradaId { get; set; }
        
    }
}
