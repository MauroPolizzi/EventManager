using System.ComponentModel.DataAnnotations;

namespace PP.Dominio.MetaData
{
    public interface IFechaEvento
    {
        [Required(AllowEmptyStrings = true)]
        long EventoId { get; set; }
    }
}
