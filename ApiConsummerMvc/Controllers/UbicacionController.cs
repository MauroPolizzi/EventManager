using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.IServicio.Ubicacion;
using PP.Servicio.Localidad;
using PP.Servicio.Pais;
using PP.Servicio.Provincia;
using PP.Servicio.Ubicacion;

namespace ApiConsummerMvc.Controllers
{
    public class UbicacionController : Controller
    {
        private readonly UbicacionServicio _ubicacionServicio;
        private readonly LocalidadServicio _localidadServicio;
        private readonly ProvinciaServicio _provinciaServicio;
        private readonly PaisServicio _paisServicio;

        public UbicacionController()
        {
            _ubicacionServicio = new UbicacionServicio();
            _localidadServicio = new LocalidadServicio();
            _provinciaServicio = new ProvinciaServicio();
            _paisServicio = new PaisServicio();
        }

        // GET: Ubicacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(long eventoId)
        {
            try
            {
                var paises = _paisServicio.Obtener(string.Empty);
                var provincias = _provinciaServicio.Obtener(string.Empty);
                var localidades = _localidadServicio.Obtener(string.Empty);

                ViewBag.eventoId = eventoId;
                ViewBag.paises = new SelectList(paises,"Id","Descripcion");
                ViewBag.provincias = new SelectList(provincias,"Id","Descripcion");
                ViewBag.localidades = new SelectList(localidades, "Id", "Descripcion");

                return View();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public ActionResult Create(UbicacionDto dto/*, long eventoId*/)
        {
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("NombreEstablecimiento", dto.NombreEstablecimiento));
            postData.Add(new KeyValuePair<string, string>("PrimDireccion", dto.PrimDireccion));
            postData.Add(new KeyValuePair<string, string>("EventoId", $"{dto.EventoId}"));
            postData.Add(new KeyValuePair<string, string>("SegDireccion", $"{dto.SegDireccion}"));
            postData.Add(new KeyValuePair<string, string>("LocalidadId", $"{dto.LocalidadId}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Ubicacion", content)
                .ContinueWith((postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", "Evento");
        }
    }
}