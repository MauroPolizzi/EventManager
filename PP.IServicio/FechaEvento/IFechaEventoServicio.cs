using System.Collections.Generic;

namespace PP.IServicio.FechaEvento
{
    public interface IFechaEventoServicio
    {
        void Agregar(FechaEventoDto dto);

        void Eliminar(long id);

        void Modificar(FechaEventoDto dto);

        IEnumerable<FechaEventoDto> Obtener(string cadenaBuscar);

        FechaEventoDto ObtenerPorId(long id);
    }
}
