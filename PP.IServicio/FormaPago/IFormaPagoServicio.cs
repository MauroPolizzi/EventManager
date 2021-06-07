using System.Collections.Generic;

namespace PP.IServicio.FormaPago
{
    public interface IFormaPagoServicio
    {
        void Agregar(FormaPagoDto dto);

        void Eliminar(long id);

        void Modificar(FormaPagoDto dto);

        IEnumerable<FormaPagoDto> Obtener(string cadenaBuscar);

        FormaPagoDto ObtenerPorId(long id);

        void Guardar();
    }
}
