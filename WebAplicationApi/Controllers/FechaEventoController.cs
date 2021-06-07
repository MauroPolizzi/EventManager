using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.FechaEvento;
using PP.Servicio.FechaEvento;

namespace WebAplicationApi.Controllers
{
    public class FechaEventoController : ApiController
    {
        private readonly IFechaEventoServicio _servicio;

        public FechaEventoController(FechaEventoServicio servicio)
        {
            _servicio = servicio;
        }

        public IEnumerable<FechaEventoDto> Get()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public FechaEventoDto ObtenerPorId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(FechaEventoDto dto)
        {
            _servicio.Agregar(dto);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public FechaEventoDto Modificar(FechaEventoDto dto)
        {
            _servicio.Modificar(dto);
            return dto;
        }

        [HttpDelete]
        public string Eliminar(long id)
        {
            _servicio.Eliminar(id);
            return "Se eliminio correctaente";
        }
    }
}
