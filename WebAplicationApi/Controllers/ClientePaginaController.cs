using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.PaginaCliente;
using PP.Servicio.ClientePagina;

namespace WebAplicationApi.Controllers
{
    public class ClientePaginaController : ApiController
    {
        private readonly IClientePaginaServicio _clientePaginaServicio;

        public ClientePaginaController(ClientePaginaServicio clientePaginaServicio)
        {
            _clientePaginaServicio = clientePaginaServicio;
        }

        // GET: api/ClientePagina
        public IEnumerable<ClientePaginaDto> GetClientePagina()
        {
            return _clientePaginaServicio.Obtener(string.Empty);
        }

        // GET: api/ClientePagina/5
        [HttpGet]
        public ClientePaginaDto ObtenerPorId(long id)
        {
            return _clientePaginaServicio.ObtenerPorId(id);
        }

        // POST: api/ClientePagina
        [HttpPost]
        public string AgregarClientePagina(ClientePaginaDto dto)
        {
            _clientePaginaServicio.Agregar(dto);
            _clientePaginaServicio.Guardar();
            return "El Cliente se Agrego Correctamente";
        }

        // PUT: api/ClientePagina/5
        [HttpPut]
        public ClientePaginaDto ModificarClientePagina(ClientePaginaDto dto)
        {
            _clientePaginaServicio.Modificar(dto);
            _clientePaginaServicio.Guardar();
            return dto;
        }

        // DELETE: api/ClientePagina/5
        [HttpDelete]
        public string EliminarClientePagina(long id)
        {
            _clientePaginaServicio.Eliminar(id);
            _clientePaginaServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
