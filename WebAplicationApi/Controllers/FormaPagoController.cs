using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.FormaPago;
using PP.Servicio.FormaPago;

namespace WebAplicationApi.Controllers
{
    public class FormaPagoController : ApiController
    {
        private readonly IFormaPagoServicio _formaPagoServicio;

        public FormaPagoController(FormaPagoServicio formaPago)
        {
            _formaPagoServicio = formaPago;
        }

        // GET: api/FormaPago
        public IEnumerable<FormaPagoDto> GetFormaPago()
        {
            return _formaPagoServicio.Obtener(string.Empty);
        }

        // GET: api/FormaPago/5
        [HttpGet]
        public FormaPagoDto ObtenerPorId(long id)
        {
            return _formaPagoServicio.ObtenerPorId(id);
        }

        // POST: api/FormaPago
        [HttpPost]
        public string AgregarFormaPago(FormaPagoDto dto)
        {
            _formaPagoServicio.Agregar(dto);
            _formaPagoServicio.Guardar();
            return "Se Agrego con Exito";
        }

        // PUT: api/FormaPago/5
        [HttpPut]
        public FormaPagoDto ModificarFormaPago(FormaPagoDto dto)
        {
            _formaPagoServicio.Modificar(dto);
            _formaPagoServicio.Guardar();
            return dto;
        }

        // DELETE: api/FormaPago/5
        public string EliminarFormaPago(long id)
        {
            _formaPagoServicio.Eliminar(id);
            _formaPagoServicio.Guardar();
            return "Se Elimino Correctamente";
        }
    }
}
