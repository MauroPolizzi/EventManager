using PP.InfraestructuraRepositorio;
using PP.IServicio.Inscripcion;
using PP.Servicio.Inscripcion;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ApiConsummerMvc.Controllers
{
    public class InscripcionController : Controller
    {
        

        private readonly InscripcionRepositorio _inscripcionRepositorio;
        private readonly InscripcionServicio _inscripcionServicio;

        public InscripcionController()
        {
            _inscripcionRepositorio = new InscripcionRepositorio();
            _inscripcionServicio = new InscripcionServicio(_inscripcionRepositorio);
        }

        // GET: Inscripcion
        public ActionResult Index()
        {
            var inscripcion = GetFromApi();
            return View(inscripcion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InscripcionDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("TiempoInscripcion", $"{dto.TiempoInscripcion}"));
            postData.Add(new KeyValuePair<string, string>("ClienteID", $"{1}"));
            postData.Add(new KeyValuePair<string, string>("EventoId", $"{1}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Inscripcion", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        //=========================================//
        public ActionResult Edit(long id)
        {
            var inscripcion = _inscripcionServicio.ObtenerPorId(id);
            return View(inscripcion);
        }

        [HttpPost]
        public ActionResult Edit(InscripcionDto dto)
        {
            //var client = new HttpClient();

            //// This is the postdata
            //var postData = new List<KeyValuePair<string, string>>();
            //postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            //postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            //postData.Add(new KeyValuePair<string, string>("Respuesta", $"{dto.Respuesta}"));
            //postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            //postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));


            //HttpContent content = new FormUrlEncodedContent(postData);

            //client.PutAsync("http://localhost:20625/api/PreguntaFrecuente", content).ContinueWith(
            //    (postTask) =>
            //    {
            //        postTask.Result.EnsureSuccessStatusCode();
            //    });

            ////_paisServicio.Modificar(dto);
            return RedirectToAction("Index");
        }

        //=========================================//

        public ActionResult Delete(long id)
        {
            var inscripcion = _inscripcionServicio.ObtenerPorId(id);
            return View(inscripcion);
        }

        [HttpPost]
        public ActionResult DeleteInscipcion(long id)
        {
            //var client = new HttpClient();



            //client.DeleteAsync($"http://localhost:20625/api/PreguntaFrecuente/{id}").ContinueWith(
            //    (postTask) =>
            //    {
            //        postTask.Result.EnsureSuccessStatusCode();
            //    });
            ////_paisServicio.Eliminar(id);
            return RedirectToAction("Index");
        }

        //=========================================//

        public ActionResult Details(long id, string cadanaBuscar)
        {
            var inscripcion = _inscripcionServicio.ObtenerPorId(id);
            ViewBag.inscrip = inscripcion;

            return View();
        }

        //=============================================//

        private IEnumerable<InscripcionDto> GetFromApi()
        {
            try
            {
                var listaPreguntas = new List<InscripcionDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Inscripcion")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<InscripcionDto>>();
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