using PP.IServicio.Inscripcion;
using PP.Servicio.Inscripcion;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAplicationApi.Controllers
{
    public class InscripcionController : ApiController
    {
        private readonly IInscripcionServicio _inscripcionServicio;

        public InscripcionController(InscripcionServicio inscripcionServicio)
        {
            _inscripcionServicio = inscripcionServicio;
        }

        public IEnumerable<InscripcionDto> GetInscripciones()
        {
            return _inscripcionServicio.Obtener();
        }

        [HttpGet]
        public InscripcionDto ObtenerPorId(long id)
        {
            return _inscripcionServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarInscripcion(InscripcionDto dto)
        {
            _inscripcionServicio.Agregar(dto);
            _inscripcionServicio.Guardar();
            return "Se Agrego correctamente.";
        }

        [HttpDelete]
        public string EliminarInscripcion(long id)
        {
            _inscripcionServicio.Eliminar(id);
            _inscripcionServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarInscripcion(InscripcionDto dto)
        {
            _inscripcionServicio.Modificar(dto);
            _inscripcionServicio.Guardar();
            return "Se modifico correctamente";
        }
    }
}
