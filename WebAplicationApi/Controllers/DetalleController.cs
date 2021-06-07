using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Detalle;
using PP.Servicio.Detalle;

namespace WebAplicationApi.Controllers
{
    public class DetalleController : ApiController
    {
        private readonly IDetalleServicio _servicio;

        public DetalleController (DetalleServicio servicio)
        {
            _servicio = servicio;
        }

        public IEnumerable<DetalleDto> Get()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public DetalleDto ObtenerPorId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(DetalleDto dto)
        {
            _servicio.Agregar(dto);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public DetalleDto Modificar(DetalleDto dto)
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
