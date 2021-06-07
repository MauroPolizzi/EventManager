using PP.IServicio.Configuracion;
using PP.Servicio.Configuracion;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAplicationApi.Controllers
{
    public class ConfiguracionController : ApiController
    {

        private readonly IConfiguracionServicio _confServicio;

        public ConfiguracionController(ConfiguracionServicio confServicio)
        {
            _confServicio = confServicio;
        }

        public IEnumerable<ConfiguracionDto> GetConfiguracion()
        {
            return _confServicio.Obtener();
        }

        [HttpGet]
        public ConfiguracionDto ObtenerPorId(long id)
        {
            return _confServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarConfiguracion(ConfiguracionDto dto)
        {
            _confServicio.Agregar(dto);
            _confServicio.Guardar();
            return "Se Agrego correctamente.";
        }

        [HttpDelete]
        public string EliminarConfiguracion(long id)
        {
            _confServicio.Eliminar(id);
            _confServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarEvento(ConfiguracionDto dto)
        {
            _confServicio.Modificar(dto);
            _confServicio.Guardar();
            return "Se modifico correctamente";
        }
    }
}
