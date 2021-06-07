using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.PlanTarjeta;
using PP.Servicio.PlanTarjeta;
using PP.Servicio.Tarjeta;

namespace ApiConsummerMvc.Controllers
{
    public class PlanTarjetaController : Controller
    {
        private readonly TarjetaServicio _tarjetaServicio;
        private readonly TarjetaRepositorio _tarjetaRepositorio;
        private readonly PlanTarjetaServicio _planTarjetaServicio;
        private readonly PlanTarjetaRepositorio _planTarjetaRepositorio;

        public PlanTarjetaController()
        {
            _tarjetaServicio = new TarjetaServicio(_tarjetaRepositorio);
            _tarjetaRepositorio = new TarjetaRepositorio();
            _planTarjetaServicio = new PlanTarjetaServicio(_planTarjetaRepositorio);
            _planTarjetaRepositorio = new PlanTarjetaRepositorio();
        }

        // GET: PlanTarjeta
        public ActionResult Index(long id)
        {
            var planTarjeta = GetFromApi(id);
            ViewBag.tarjetaId = id;
            return View(planTarjeta);
        }

        private IEnumerable<PlanTarjetaDto> GetFromApi(long tarjetaId)
        {
            try
            {
                var listaPlan = new List<PlanTarjetaDto>();
                var client = new HttpClient();

                var obtenerDatos = client.GetAsync("http://localhost:20625/api/PlanTarjeta")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<PlanTarjetaDto>>();
                            leerDatos.Wait();

                            foreach (var plan in leerDatos.Result)
                            {
                                if (plan.TarjetaId == tarjetaId)
                                {
                                    listaPlan.Add(plan);
                                }
                            }
                        }
                    });

                obtenerDatos.Wait();
                return listaPlan;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Create(long id)
        {
            ViewBag.tarjetaId = id;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PlanTarjetaDto dto)
        {
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Codigo", $"{dto.Codigo}"));
            postData.Add(new KeyValuePair<string, string>("Interes", $"{dto.Interes}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            postData.Add(new KeyValuePair<string, string>("TarjetaId", $"{dto.TarjetaId}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/PlanTarjeta", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", "PlanTarjeta", new {id = dto.TarjetaId});
        }
    }
}