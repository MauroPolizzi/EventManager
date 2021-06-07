using System.Collections.Generic;

namespace PP.IServicio.Provincia
{
    public interface IProvinciaServicio
    {
        void Agregar(ProvinciaDto dto);

        void Modificar(ProvinciaDto dto);

        void Eliminar(long id);

        IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar);

        IEnumerable<ProvinciaDto> ObtenerPorPais(long id);
        ProvinciaDto ObtenerPorId(long id);

        void Guardar();
    }
}
