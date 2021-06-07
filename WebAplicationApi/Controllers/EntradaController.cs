using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Entrada;
using PP.IServicio.Pais;
using PP.Servicio.Entrada;

namespace WebAplicationApi.Controllers
{
    public class EntradaController : ApiController
    {
        private readonly IEntradaServicio _entradaServicio;

        public EntradaController(EntradaServicio entradaServicio)
        {
            _entradaServicio = entradaServicio;
        }

        public IEnumerable<EntradaDto> Get()
        {
            return _entradaServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public EntradaDto ObtenerPorId(long id)
        {
            return _entradaServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(EntradaDto pais)
        {
            _entradaServicio.Agregar(pais);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public EntradaDto Modificar(EntradaDto pais)
        {
            _entradaServicio.Modificar(pais);
            return pais;
        }

        [HttpDelete]
        public string Eliminar(long id)
        {
            _entradaServicio.Eliminar(id);
            return "Se eliminio correctaente";
        }
    }
}
