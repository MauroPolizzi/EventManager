using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Pais
{
    public class PaisDto : DtoBase
    {
        public string Descripcion { get; set; }

        public  bool Eliminado { get; set; }
    }
}
