using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Tarjeta;
using PP.Servicio.Tarjeta;

namespace WebAplicationApi.Controllers
{
    public class TarjetaController : ApiController
    {
        private readonly ITarjetaServicio _tarjetaServicio;

        public TarjetaController(TarjetaServicio tarjetaServicio)
        {
            _tarjetaServicio = tarjetaServicio;
        }

        public IEnumerable<TarjetaDto> GetTarjeta()
        {
            return _tarjetaServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public TarjetaDto ObtenerPorId(long id)
        {
            return _tarjetaServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarTarjeta(TarjetaDto dto)
        {
            _tarjetaServicio.Agregar(dto);
            _tarjetaServicio.Guardar();
            return "Se Agrego Correctamente";
        }

        [HttpPut]
        public TarjetaDto ModificarTransferencia(TarjetaDto dto)
        {
            _tarjetaServicio.Modificar(dto);
            _tarjetaServicio.Guardar();
            return dto;
        }

        [HttpDelete]
        public string EliminarTarjeta(long id)
        {
            _tarjetaServicio.Eliminar(id);
            _tarjetaServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
