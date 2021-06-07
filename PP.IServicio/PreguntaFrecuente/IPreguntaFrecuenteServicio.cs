using System.Collections.Generic;

namespace PP.IServicio.PreguntaFrecuente
{
    public interface IPreguntaFrecuenteServicio
    {
        void Agregar(PreguntaFrecuenteDto dto);

        void Eliminar(long id);

        void Modificar(PreguntaFrecuenteDto dto);

        IEnumerable<PreguntaFrecuenteDto> Obtener(string cadenaBuscar);

        PreguntaFrecuenteDto ObtenerPorId(long id);

        void Guardar();
    }
}
