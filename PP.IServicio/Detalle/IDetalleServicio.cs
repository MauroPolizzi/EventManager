using System.Collections.Generic;

namespace PP.IServicio.Detalle
{
    public interface IDetalleServicio
    {
        void Agregar(DetalleDto dto);

        void Eliminar(long id);

        void Modificar(DetalleDto dto);

        IEnumerable<DetalleDto> Obtener(string cadenaBuscar);

         DetalleDto ObtenerPorId (long id);
    }
}
