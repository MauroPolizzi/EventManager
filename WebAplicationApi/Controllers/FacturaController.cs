using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Factura;
using PP.Servicio.Factura;

namespace WebAplicationApi.Controllers
{
    public class FacturaController : ApiController
    {
        private readonly IFacturaServicio _servicio;

        public FacturaController(FacturaServicio servicio)
        {
            _servicio = servicio;
        }

        public IEnumerable<FacturaDto> Get()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public FacturaDto ObtenerPorId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string Agregar(FacturaDto pais)
        {
            _servicio.Agregar(pais);
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public FacturaDto Modificar(FacturaDto pais)
        {
            _servicio.Modificar(pais);
            return pais;
        }

        [HttpDelete]
        public string Eliminar(long id)
        {
            _servicio.Eliminar(id);
            return "Se eliminio correctaente";
        }
    }
}
