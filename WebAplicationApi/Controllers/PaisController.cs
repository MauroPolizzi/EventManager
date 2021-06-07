using System.Collections.Generic;
using System.Web.Http;
using PP.IServicio.Pais;
using PP.IServicio.Provincia;
using PP.Servicio.Pais;
using PP.Servicio.Provincia;

namespace WebAplicationApi.Controllers
{
    public class PaisController : ApiController
    {
        //private readonly Repositorio<Pais> _repositorio = new Repositorio<Pais>();

        private readonly IPaisServicio _servicio;
        private readonly IProvinciaServicio _provinciaServicio;

        public PaisController(PaisServicio repositorio, ProvinciaServicio provinciaServicio)
        {
            _servicio = repositorio;
            _provinciaServicio = provinciaServicio;
        }

        public IEnumerable<PaisDto> GetPaises()
        {
            return _servicio.Obtener(string.Empty);
        }

        [HttpGet]
        public PaisDto ObtenerPaisId(long id)
        {
            return _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public string AgregarPais(PaisDto pais)
        {
            _servicio.Agregar(pais);
            _servicio.Guardar();
            return "El Pais de Agrego Correctamente.";
        }

        [HttpPut]
        public PaisDto ModificarPais(PaisDto pais)
        {
            _servicio.Modificar(pais);
            _servicio.Guardar();
            return pais;
        }

        [HttpDelete]
        public string EliminarPais(long id)
        {
            _servicio.Eliminar(id);
            _servicio.Guardar();
            return "Se eliminio correctaente";
        }
    }
}