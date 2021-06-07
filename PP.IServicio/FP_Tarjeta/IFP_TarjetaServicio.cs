using System.Collections.Generic;

namespace PP.IServicio.FP_Tarjeta
{
    public interface IFP_TarjetaServicio
    {
        void Agregar(FP_TarjetaDto dto);

        void Eliminar(long id);

        void Modificar(FP_TarjetaDto dto);

        IEnumerable<FP_TarjetaDto> Obtener(int cadenaBuscar);

        FP_TarjetaDto ObtenerPorId(long id);

        void Guardar();
    }
}
