using System.Collections.Generic;

namespace PP.IServicio.PlanTarjeta
{
    public interface IPlanTarjetaServicio
    {
        void Agregar(PlanTarjetaDto dto);

        void Eliminar(long id);

        void Modificar(PlanTarjetaDto dto);

        IEnumerable<PlanTarjetaDto> Obtener(string cadenaBuscar);

        PlanTarjetaDto ObtenerPorId(long id);

        void Guardar();
    }
}
