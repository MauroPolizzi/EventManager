using System.Collections.Generic;

namespace PP.IServicio.Localidad
{
    public interface ILocalidadServicio
    {
        void Agregar(LocalidadDto dto);

        void Eliminar(long id);

        void Modificar(LocalidadDto dto);

        IEnumerable<LocalidadDto> Obtener(string cadenaBuscar);

        LocalidadDto ObtenerPorId(long id);
    }
}
