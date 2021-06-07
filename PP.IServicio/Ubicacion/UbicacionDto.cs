using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Ubicacion
{
    public class UbicacionDto : DtoBase
    {
        public string NombreEstablecimiento { get; set; }

        public string PrimDireccion { get; set; }

        public string SegDireccion { get; set; }

        public long EventoId { get; set; }

        public long LocalidadId { get; set; }

        public bool Eliminado { get; set; }
    }
}
