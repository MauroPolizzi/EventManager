using System.Collections.Generic;

namespace PP.IServicio.Tarjeta
{
    public interface ITarjetaServicio
    {
        void Agregar(TarjetaDto dto);

        void Eliminar(long id);

        void Modificar(TarjetaDto dto);

        IEnumerable<TarjetaDto> Obtener(string cadenaBuscar);

        TarjetaDto ObtenerPorId(long id);

        void Guardar();
    }
}
