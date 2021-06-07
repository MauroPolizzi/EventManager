using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Ubicacion;

namespace WebAplicationApi.Controllers
{
    public class UbicacionController : ApiController
    {
        private readonly IUbicacionServicio _servicio;

        public UbicacionController(IUbicacionServicio servicio)
        {
            _servicio = servicio;
        }

        public IEnumerable<UbicacionDto> Get()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public UbicacionDto ObtenerPorId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(UbicacionDto dto)
        {
            _servicio.Agregar(dto);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public UbicacionDto Modificar(UbicacionDto dto)
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
