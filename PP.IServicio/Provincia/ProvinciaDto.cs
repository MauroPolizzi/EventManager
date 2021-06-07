using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Provincia
{
    public class ProvinciaDto : DtoBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long PaisId { get; set; }

        public string PaisDescripcion { get; set; }
    }
}
