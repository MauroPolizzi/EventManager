using System.Collections.Generic;

namespace PP.IServicio.Ubicacion
{
    public interface IUbicacionServicio
    {
        void Agregar(UbicacionDto dto);

        void Eliminar(long id);

        void Modificar(UbicacionDto dto);

        IEnumerable<UbicacionDto> Obtener(string cadenaBuscar);

        IEnumerable<UbicacionDto> ObtenerPorLocalidad(string cadenaBuscar, long localidadId);

        UbicacionDto ObtenerPorId(long id);
    }
}
