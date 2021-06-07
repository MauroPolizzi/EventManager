using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Banco;
using PP.Servicio.Banco;

namespace WebAplicationApi.Controllers
{
    public class BancoController : ApiController
    {
        private readonly IBancoServicio _bancoServicio;

        public BancoController(BancoServicio bancoServicio)
        {
            _bancoServicio = bancoServicio;
        }

        public IEnumerable<BancoDto> GetBanco()
        {
            return _bancoServicio.Obtener(string.Empty);
        }

        [HttpGet]
        public BancoDto ObtenerPorId(long id)
        {
            return _bancoServicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarBanco(BancoDto dto)
        {
            _bancoServicio.Agregar(dto);
            _bancoServicio.Guardar();
            return "Se Agrego Correctamente";
        }

        [HttpPut]
        public BancoDto ModificarBanco(BancoDto dto)
        {
            _bancoServicio.Modificar(dto);
            _bancoServicio.Guardar();
            return dto;
        }

        [HttpDelete]
        public string EliminarBanco(long id)
        {
            _bancoServicio.Eliminar(id);
            _bancoServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
