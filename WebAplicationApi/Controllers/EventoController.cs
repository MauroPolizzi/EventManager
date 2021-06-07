using PP.IServicio.Evento;
using PP.Servicio.Evento;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAplicationApi.Controllers
{
    public class EventoController : ApiController
    {

        private readonly IEventoServicio _eventoServicio;

        public EventoController(EventoServicio eventoServicio)
        {
            _eventoServicio = eventoServicio;
        }

        public IEnumerable<EventoDto> GetEventos()
        {
            return _eventoServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public EventoDto ObtenerPorId(long id)
        {
            return _eventoServicio.ObtenerPorId(id);
        }

        //[HttpPost]
        //public string AgregarEvento(EventoDto dto)
        //{
        //    //_eventoServicio.Agregar(dto);
        //    //_eventoServicio.Guardar();
        //    //return "Se Agrego correctamente.";
        //}

        [HttpDelete]
        public string EliminarEvento(long id)
        {
            _eventoServicio.Eliminar(id);
            _eventoServicio.Guardar();
            return "Se elimino correctamente";
        }

        [HttpPut]
        public string ModificarEvento(EventoDto dto)
        {
            _eventoServicio.Modificar(dto);
            _eventoServicio.Guardar();
            return "Se modifico correctamente";
        }
    }
}
