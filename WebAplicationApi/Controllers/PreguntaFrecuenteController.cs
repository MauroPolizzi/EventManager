using PP.IServicio.PreguntaFrecuente;
using PP.Servicio.PreguntaFrecuente;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAplicationApi.Controllers
{
    public class PreguntaFrecuenteController : ApiController
    {
        private readonly IPreguntaFrecuenteServicio _pFrecuenteServicio;

        public PreguntaFrecuenteController(PreguntaFrecuenteServicio pFrecuenteServicio)
        {
            _pFrecuenteServicio = pFrecuenteServicio;
        }

        public IEnumerable<PreguntaFrecuenteDto> GetPreguntas()
        {
            return _pFrecuenteServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public PreguntaFrecuenteDto ObtenerPorId(long id)
        {
            return _pFrecuenteServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarPregunta(PreguntaFrecuenteDto dto)
        {
            _pFrecuenteServicio.Agregar(dto);
            _pFrecuenteServicio.Guardar();
            return "Se Agrego correctamente.";
        }

        [HttpDelete]
        public string EliminarPregunta(long id)
        {
            _pFrecuenteServicio.Eliminar(id);
            _pFrecuenteServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarPregunta(PreguntaFrecuenteDto dto)
        {
            _pFrecuenteServicio.Modificar(dto);
            _pFrecuenteServicio.Guardar();
            return "Se modifico correctamente";
        }
    }
}
