using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.FP_Tarjeta;
using PP.Servicio.FP_Tarjeta;

namespace WebAplicationApi.Controllers
{
    public class FpTarjetaController : ApiController
    {
         private readonly IFP_TarjetaServicio _fpTarjetaServicio;

        public FpTarjetaController(FP_TarjetaServicio fpTarjetaServicio)
        {
            _fpTarjetaServicio = fpTarjetaServicio;
        }

        //public IEnumerable<FP_TarjetaDto> GetFpTTarjeta()
        //{
        //    return _fpTarjetaServicio.Obtener();
        //}

        [HttpGet]
        public FP_TarjetaDto ObtenerPorId(long id)
        {
            return _fpTarjetaServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarFpTarjeta(FP_TarjetaDto dto)
        {
            _fpTarjetaServicio.Agregar(dto);
            _fpTarjetaServicio.Guardar();
            return "Se Agrego Correctamente";
        }

        [HttpPut]
        public FP_TarjetaDto ModificarFpTarjeta(FP_TarjetaDto dto)
        {
            _fpTarjetaServicio.Modificar(dto);
            _fpTarjetaServicio.Guardar();
            return dto;
        }

        [HttpDelete]
        public string EliminarFpTarjeta(long id)
        {
            _fpTarjetaServicio.Eliminar(id);
            _fpTarjetaServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
    
}
