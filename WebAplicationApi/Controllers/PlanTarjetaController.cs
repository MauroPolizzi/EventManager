using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.PlanTarjeta;
using PP.Servicio.PlanTarjeta;

namespace WebAplicationApi.Controllers
{
    public class PlanTarjetaController : ApiController
    {
        private readonly IPlanTarjetaServicio _planTarjetaServicio;

        public PlanTarjetaController(PlanTarjetaServicio planTarjeta)
        {
            _planTarjetaServicio = planTarjeta;
        }

        public IEnumerable<PlanTarjetaDto> GetPlanTarjeta()
        {
            return _planTarjetaServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public PlanTarjetaDto ObtenerPorId(long id)
        {
            return _planTarjetaServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarPlanTarjeta(PlanTarjetaDto dto)
        {
            _planTarjetaServicio.Agregar(dto);
            _planTarjetaServicio.Guardar();
            return "Se Agrego Correctamente";
        }

        [HttpPut]
        public PlanTarjetaDto ModificarPlanTarjeta(PlanTarjetaDto dto)
        {
            _planTarjetaServicio.Modificar(dto);
            _planTarjetaServicio.Guardar();
            return dto;
        }

        [HttpDelete]
        public string EliminarPlanTarjeta(long id)
        {
            _planTarjetaServicio.Eliminar(id);
            _planTarjetaServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
