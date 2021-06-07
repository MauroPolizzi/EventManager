using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Usuario;
using PP.Servicio.Usuario;

namespace WebAplicationApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        // GET: api/Usuario
        public IEnumerable<UsuarioDto> GetUsuario()
        {
            return _usuarioServicio.Obtener(string.Empty);
        }

        // GET: api/Usuario/5
        [HttpGet]
        public UsuarioDto ObtenerPorId(long id)
        {
            return _usuarioServicio.ObtenerPorId(id);
        }

        // POST: api/Usuario
        [HttpPost]
        public string AgregarUsuario(UsuarioDto dto)
        {
            _usuarioServicio.Agregar(dto);
            _usuarioServicio.Guardar();
            return "El Usuario se Agrego Correctamente";
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public UsuarioDto ModificarUsuario(UsuarioDto dto)
        {
            _usuarioServicio.Modificar(dto);
            _usuarioServicio.Guardar();
            return dto;
        }

        // DELETE: api/Usuario/5
        public string EliminarUsuario(long id)
        {
            _usuarioServicio.Eliminar(id);
            _usuarioServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
