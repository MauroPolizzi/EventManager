using PP.IServicio.TipoEvento;
using PP.Servicio.TipoEvento;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAplicationApi.Controllers
{
    public class TipoEventoController : ApiController
    {
        private readonly ITipoEventoServicio _tipoEventoServicio;

        public TipoEventoController(TipoEventoServicio tipoEventoServicio)
        {
            _tipoEventoServicio = tipoEventoServicio;
        }

        public IEnumerable<TipoEventoDto> GetTipoEventos()
        {
            return _tipoEventoServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public TipoEventoDto ObtenerPorId(long id)
        {
            return _tipoEventoServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarTipoEvento(TipoEventoDto dto)
        {
            _tipoEventoServicio.Agregar(dto);
            _tipoEventoServicio.Guardar();
            return "Se Agrego correctamente.";
        }

        [HttpDelete]
        public string EliminarTipoEvento(long id)
        {
            _tipoEventoServicio.Eliminar(id);
            _tipoEventoServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarTipoEvento(TipoEventoDto dto)
        {
            _tipoEventoServicio.Modificar(dto);
            _tipoEventoServicio.Guardar();
            return "Se modifico correctamente";
        }
    }
}
