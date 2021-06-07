using System.Collections.Generic;

namespace PP.IServicio.FP_Transferencia
{
    public interface IFP_TransferenciaServicio
    {
        void Agregar(FP_TransferenciaDto dto);

        void Eliminar(long id);

        void Modificar(FP_TransferenciaDto dto);

        IEnumerable<FP_TransferenciaDto> Obtener(int cadenaBuscar);

        FP_TransferenciaDto ObtenerPorId(long id);

        void Guardar();
    }
}
