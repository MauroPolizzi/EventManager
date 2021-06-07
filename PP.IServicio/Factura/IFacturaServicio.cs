using System.Collections.Generic;

namespace PP.IServicio.Factura
{
    public interface IFacturaServicio
    {
        void Agregar(FacturaDto dto);

        void Eliminar(long id);

        void Modificar(FacturaDto dto);

        IEnumerable<FacturaDto> Obtener(string cadenaBuscar);

        FacturaDto ObtenerPorId(long id);
    }
}
