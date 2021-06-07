using System.Collections.Generic;

namespace PP.IServicio.Inscripcion
{
    public interface IInscripcionServicio
    {
        void Agregar(InscripcionDto dto);

        void Eliminar(long id);

        void Modificar(InscripcionDto dto);

        IEnumerable<InscripcionDto> Obtener();

        InscripcionDto ObtenerPorId(long id);

        void Guardar();
    }
}
