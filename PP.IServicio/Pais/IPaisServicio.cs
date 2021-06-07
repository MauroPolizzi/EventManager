using System.Collections.Generic;

namespace PP.IServicio.Pais
{
    public interface IPaisServicio
    {
        void Agregar(PaisDto dto);

        void Eliminar(long id);

        void Modificar(PaisDto dto);

        IEnumerable<PaisDto> Obtener(string cadenaBuscar);

        PaisDto ObtenerPorId(long id);

        void Guardar();
    }
}
