using System.Collections.Generic;

namespace PP.IServicio.Entrada
{
    public interface IEntradaServicio
    {
        void Agregar(EntradaDto dto);

        void Eliminar(long id);

        void Modificar(EntradaDto dto);

        IEnumerable<EntradaDto> Obtener(string cadenaBuscar);

        EntradaDto ObtenerPorId(long id);
    }
}
