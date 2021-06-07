using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Provincia;
using PP.Servicio.Provincia;

namespace WebAplicationApi.Controllers
{
    public class ProvinciaController : ApiController
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public ProvinciaController(ProvinciaServicio provinciaServicio)
        {
            _provinciaServicio = provinciaServicio;
        }
        
        public IEnumerable<ProvinciaDto> GetProvincias ()
        {
            return _provinciaServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public ProvinciaDto ObtenerPorId(long id)
        {
            return _provinciaServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarProvincia (ProvinciaDto dto)
        {
            _provinciaServicio.Agregar(dto);
            _provinciaServicio.Guardar();
            return "Se Agrego correctamente.";
        }

        [HttpDelete]
        public string EliminarProvincia (long id)
        {
            _provinciaServicio.Eliminar(id);
            _provinciaServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarProvincia (ProvinciaDto dto)
        {
            _provinciaServicio.Modificar(dto);
            _provinciaServicio.Guardar();
            return "Se modifico correctamente";
        }


    }
}