using PP.Servicio.Base.DtoBase;

namespace PP.IServicio.Usuario
{
    public class UsuarioDto : DtoBase
    {
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public long ClienteId { get; set; }
    }
}
