using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.FP_Transferencia;
using PP.Servicio.FP_Transferencia;

namespace WebAplicationApi.Controllers
{
    public class FpTransferenciaController : ApiController
    {
        private readonly IFP_TransferenciaServicio _fpTransferencia;

        public FpTransferenciaController(FP_TransferenciaServicio fpTransferencia)
        {
            _fpTransferencia = fpTransferencia;
        }

        //public IEnumerable<FP_TransferenciaDto> GetTransferencia()
        //{
        //    return _fpTransferencia.Obtener(string.Empty);
        //}

        [HttpGet]
        public FP_TransferenciaDto ObtenerPorId(long id)
        {
            return _fpTransferencia.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarTransferencia(FP_TransferenciaDto dto)
        {
            _fpTransferencia.Agregar(dto);
            _fpTransferencia.Guardar();
            return "Se Agrego Correctamente";
        }

        [HttpPut]
        public FP_TransferenciaDto ModificarTransferencia(FP_TransferenciaDto dto)
        {
            _fpTransferencia.Modificar(dto);
            _fpTransferencia.Guardar();
            return dto;
        }

        [HttpDelete]
        public string EliminarTransferencia(long id)
        {
            _fpTransferencia.Eliminar(id);
            _fpTransferencia.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
