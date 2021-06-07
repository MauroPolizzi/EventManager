using System.Collections.Generic;

namespace PP.IServicio.TipoEvento
{
    public interface ITipoEventoServicio
    {
        void Agregar(TipoEventoDto dto);

        void Eliminar(long id);

        void Modificar(TipoEventoDto dto);

        IEnumerable<TipoEventoDto> Obtener(string cadenaBuscar);

        TipoEventoDto ObtenerPorId(long id);

        void Guardar();
    }
}
