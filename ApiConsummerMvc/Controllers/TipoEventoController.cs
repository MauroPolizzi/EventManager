using PP.InfraestructuraRepositorio;
using PP.IServicio.TipoEvento;
using PP.Servicio.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiConsummerMvc.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly TipoEventoRepositorio _tipoEventorepositorio;
        private readonly TipoEventoServicio _tipoEventoServicio;

        public TipoEventoController()
        {
            _tipoEventorepositorio = new TipoEventoRepositorio();
            _tipoEventoServicio = new TipoEventoServicio(_tipoEventorepositorio);
        }
        // GET: TipoEvento
        public ActionResult Index()
        {
            var tipoEventos = GetFromApi();
            return View(tipoEventos);
            
        }        
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoEventoDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            
            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/TipoEvento", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        //=========================================//
        public ActionResult Edit(long id)
        {
            var tipoEvento = _tipoEventoServicio.ObtenerPorId(id);
            return View(tipoEvento);
        }

        [HttpPost]
        public ActionResult Edit(TipoEventoDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));


            HttpContent content = new FormUrlEncodedContent(postData);

            client.PutAsync("http://localhost:20625/api/TipoEvento", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            //_paisServicio.Modificar(dto);
            return RedirectToAction("Index");
        }

        //=========================================//

        public ActionResult Delete(long id)
        {
            var tipoEvento = _tipoEventoServicio.ObtenerPorId(id);
            return View(tipoEvento);
        }

        [HttpPost]
        public ActionResult DeleteTipoEvento(long id)
        {
            var client = new HttpClient();



            client.DeleteAsync($"http://localhost:20625/api/TipoEvento/{id}").ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });
            //_paisServicio.Eliminar(id);
            return RedirectToAction("Index");
        }

        //=========================================//

        public ActionResult Details(long id, string cadanaBuscar)
        {
            var tipoEvento = _tipoEventoServicio.ObtenerPorId(id);
            ViewBag.tEvento = tipoEvento;

            return View();
        }

        //=============================================//

        private IEnumerable<TipoEventoDto> GetFromApi()
        {
            try
            {
                var listaPreguntas = new List<TipoEventoDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/TipoEvento")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<TipoEventoDto>>();
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