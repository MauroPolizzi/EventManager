using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.PaginaCliente
{
    public class ClientePaginaDto : DtoBase
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Domicilio { get; set; }
    }
}
