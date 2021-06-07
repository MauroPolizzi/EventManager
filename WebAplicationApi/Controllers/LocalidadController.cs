using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Localidad;
using PP.IServicio.Ubicacion;
using PP.Servicio.Localidad;

namespace WebAplicationApi.Controllers
{
    public class LocalidadController : ApiController
    {
        private readonly ILocalidadServicio _servicio;

        public LocalidadController(LocalidadServicio servicio)
        {
            _servicio = servicio;
        }

        public IEnumerable<LocalidadDto> Get()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public LocalidadDto ObtenerPorId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(LocalidadDto dto)
        {
            _servicio.Agregar(dto);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public LocalidadDto Modificar(LocalidadDto dto)
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
