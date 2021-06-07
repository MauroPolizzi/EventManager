using PP.InfraestructuraRepositorio;
using PP.IServicio.Configuracion;
using PP.Servicio.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiConsummerMvc.Controllers
{
    public class ConfiguracionController : Controller
    {
        
        

        private readonly ConfiguracionRepositorio _configrepositorio;
        private readonly ConfiguracionServicio _configServicio;

        public ConfiguracionController()
        {
            _configrepositorio = new ConfiguracionRepositorio();
            _configServicio = new ConfiguracionServicio(_configrepositorio);
        }

        // GET: Configuracion
        public ActionResult Index()
        {
            var preguntas = GetFromApi();
            return View(preguntas);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConfiguracionDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Publica", $"{dto.Publica}"));
            postData.Add(new KeyValuePair<string, string>("MostrarCantidadEntradas", $"{dto.MostrarCantidadEntradas}"));
            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Configuracion", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        //=========================================//
        public ActionResult Edit(long id)
        {
            var config = _configServicio.ObtenerPorId(id);
            return View(config);
        }

        [HttpPost]
        public ActionResult Edit(ConfiguracionDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Publica", $"{dto.Publica}"));
            postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            postData.Add(new KeyValuePair<string, string>("MostrarCantidadEntradas", $"{dto.MostrarCantidadEntradas}"));
            
            postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));


            HttpContent content = new FormUrlEncodedContent(postData);

            client.PutAsync("http://localhost:20625/api/Configuracion", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            //_paisServicio.Modificar(dto);
            return RedirectToAction("Index");
        }

        //=========================================//

        

        //=========================================//

        public ActionResult Details(long id, string cadanaBuscar)
        {
            var conf = _configServicio.ObtenerPorId(id);
            ViewBag.configuracion = conf;

            return View();
        }

        //=============================================//

        private IEnumerable<ConfiguracionDto> GetFromApi()
        {
            try
            {
                var listaPreguntas = new List<ConfiguracionDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Configuracion")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<ConfiguracionDto>>();
                            leerDatos.Wait();

                            listaPreguntas = leerDatos.Result;
                        }
                    });

                obtenerDatos.Wait();
                return listaPreguntas;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}