using PP.InfraestructuraRepositorio;
using PP.IServicio.PreguntaFrecuente;
using PP.Servicio.Evento;
using PP.Servicio.PreguntaFrecuente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiConsummerMvc.Controllers
{
    public class PreguntaFrecuenteController : Controller
    {
        private readonly PreguntaFrecuenteRepositorio _ipFrecuenterepositorio;
        private readonly PreguntaFrecuenteServicio _pFrecuenteServicio;
        private readonly EventoServicio _eventoServicio;

        public PreguntaFrecuenteController()
        {
            _ipFrecuenterepositorio = new PreguntaFrecuenteRepositorio();
            _pFrecuenteServicio = new PreguntaFrecuenteServicio(_ipFrecuenterepositorio);
            _eventoServicio = new EventoServicio();
        }    
        // GET: PreguntaFrecuente
        public ActionResult Index(long id)
        {
            var preguntas = GetFromApi(id);
            ViewBag.eventoId = id;
            return View(preguntas);
        }
        private IEnumerable<PreguntaFrecuenteDto> GetFromApi(long eventoId)
        {
            try
            {
                var listaPreguntas = new List<PreguntaFrecuenteDto>();
                var client = new HttpClient();

                var obtenerDato = client.GetAsync("http://localhost:20625/api/PreguntaFrecuente")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerResultado = resultado.Content.ReadAsAsync<List<PreguntaFrecuenteDto>>();
                            leerResultado.Wait();

                            foreach (var ev in leerResultado.Result)
                            {
                                if (ev.EventoId == eventoId)
                                {
                                    listaPreguntas.Add(ev);
                                }
                            }
                        }
                    });
                obtenerDato.Wait();
                return listaPreguntas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult Create(long id)
        {
            var eventos = _eventoServicio.Obtener(string.Empty);

            ViewBag.eventoId = id;
            ViewBag.Eventos = new SelectList(eventos, "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PreguntaFrecuenteDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Respuesta", $"{dto.Respuesta}"));
            postData.Add(new KeyValuePair<string, string>("EventoId", $"{dto.EventoId}"));
            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/PreguntaFrecuente", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index","PreguntaFrecuente",new { id = dto.EventoId });
        }

        //=========================================//
        public ActionResult Edit(long id)
        {
            var pregunta = _pFrecuenteServicio.ObtenerPorId(id);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Edit(PreguntaFrecuenteDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            postData.Add(new KeyValuePair<string, string>("Respuesta", $"{dto.Respuesta}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
            

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PutAsync("http://localhost:20625/api/PreguntaFrecuente", content).ContinueWith(
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
            var pregunta = _pFrecuenteServicio.ObtenerPorId(id);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult DeletePreg(long id)
        {
            var pregunta = ObtenerPreguntaApi(id);
            var client = new HttpClient();

            

            client.DeleteAsync($"http://localhost:20625/api/PreguntaFrecuente/{id}").ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });
            //_paisServicio.Eliminar(id);
            return RedirectToAction("Index","PreguntaFrecuente", new { id = pregunta.EventoId });
            
        }
        private PreguntaFrecuenteDto ObtenerPreguntaApi(long preguntaId)
        {
            try
            {
                var pregunta = new PreguntaFrecuenteDto();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync($"http://localhost:20625/api/PreguntaFrecuente/{preguntaId}")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<PreguntaFrecuenteDto>();
                            leerDatos.Wait();

                            pregunta = leerDatos.Result;
                        }
                    });

                obtenerDatos.Wait();
                return pregunta;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        //=========================================//

        public ActionResult Details(long id, string cadanaBuscar)
        {
            var pFrecuente = _pFrecuenteServicio.ObtenerPorId(id);
            ViewBag.pregunta = pFrecuente;

            return View();
        }

        //=============================================//

        private IEnumerable<PreguntaFrecuenteDto> GetFromApi()
        {
            try
            {
                var listaPreguntas = new List<PreguntaFrecuenteDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/PreguntaFrecuente")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<PreguntaFrecuenteDto>>();
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