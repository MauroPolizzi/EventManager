using System.Collections.Generic;

namespace PP.IServicio.Evento
{
    public interface IEventoServicio
    {
        //long Agregar(EventoDto dto);
        void Agregar (EventoDetailDto dto);

        void Eliminar(long id);

        void Modificar(EventoDto dto);

        IEnumerable<EventoDto> Obtener(string cadenaBuscar);

        EventoDto ObtenerPorId(long id);

        void Guardar();
    }
}
