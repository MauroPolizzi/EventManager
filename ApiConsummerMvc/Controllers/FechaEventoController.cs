using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.IServicio.FechaEvento;
using PP.Servicio.FechaEvento;

namespace ApiConsummerMvc.Controllers
{
    public class FechaEventoController : Controller
    {
        private readonly FechaEventoServicio _fechaEventoServicio;

        public FechaEventoController()
        {
            _fechaEventoServicio = new FechaEventoServicio();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create(long id)
        {
            try
            {
                ViewBag.eventoId = id;
                return View();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpPost]
        public ActionResult Create(FechaEventoDto dto)
        {
            var fecha = new FechaEventoDto
            {
                Eliminado = dto.Eliminado,
                EventoId = dto.EventoId,
                FechaDesde = dto.FechaDesde,
                FechaHasta = dto.FechaHasta,
                HoraDesde = dto.HoraDesde,
                HoraHasta = dto.HoraHasta
            };
            _fechaEventoServicio.Agregar(fecha);

            //var client = new HttpClient();

            //var postData = new List<KeyValuePair<string,string>>();
            //postData.Add(new KeyValuePair<string, string>("FechaDesde",$"{dto.FechaDesde.Date.ToShortDateString()}"));
            //postData.Add(new KeyValuePair<string, string>("FechaHasta", $"{dto.FechaHasta.ToShortDateString()}"));
            //postData.Add(new KeyValuePair<string, string>("HoraDesde", $"{dto.HoraDesde}"));
            //postData.Add(new KeyValuePair<string, string>("HoraHasta", $"{dto.HoraHasta}"));
            //postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            //postData.Add(new KeyValuePair<string, string>("EventoId", $"{dto.EventoId}"));

            //HttpContent content = new FormUrlEncodedContent(postData);

            //client.PostAsync("http://localhost:20625/api/FechaEvento", content).ContinueWith(
            //    (postTask) =>
            //    {
            //        postTask.Result.EnsureSuccessStatusCode();
            //    });

            return RedirectToAction("Create", "Entrada", new {id = dto.EventoId});
        }
    }
}