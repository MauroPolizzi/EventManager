using PP.Dominio.Enum;
using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Entrada
{
    public class EntradaDto : DtoBase
    {
        public string NombreEntrada { get; set; }

        public int CantidadDisponible { get; set; }

        public int CantidadCompra { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public int MaximoPermitido { get; set; }

        public int MinimoPermitido { get; set; }

        public long EvetnoId { get; set; }

        public TipoEntrada TipoEntrada { get; set; } 

        public bool Eliminado { get; set; }
    }
}
