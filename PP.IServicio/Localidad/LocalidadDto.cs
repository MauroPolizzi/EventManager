using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Localidad
{
    public class LocalidadDto: DtoBase
    {
        public string Descripcion { get; set; }

        public int CodigoPostal { get; set; }

        public long ProvinciaId { get; set; }

        public bool Eliminado { get; set; }
    }
}
