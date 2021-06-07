using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Tarjeta;
using PP.Servicio.Tarjeta;

namespace ApiConsummerMvc.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly TarjetaServicio _tarjetaServicio;
        private readonly TarjetaRepositorio _tarjetaRepositorio;

        public TarjetaController()
        {
            _tarjetaRepositorio = new TarjetaRepositorio();
            _tarjetaServicio = new TarjetaServicio(_tarjetaRepositorio);
        }

        // GET: Tarjeta
        public ActionResult Index()
        {

            try
            {
                var tarjeta = GetFromApi();
                return View(tarjeta);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public ActionResult Create()
        {

            try
            {
                return View();

            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        [HttpPost]
        public ActionResult Create(TarjetaDto dto)
        {
            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", dto.Descripcion));
            postData.Add(new KeyValuePair<string, string>("Codigo", dto.Codigo));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Tarjeta", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var edit = _tarjetaServicio.ObtenerPorId(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(TarjetaDto dto)
        {
            var client = new HttpClient();
            var editData = new List<KeyValuePair<string, string>>();
            editData.Add(new KeyValuePair<string, string>("Descripcion", dto.Descripcion));
            editData.Add(new KeyValuePair<string, string>("Codigo", dto.Codigo));
            editData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            editData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            editData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));

            HttpContent content = new FormUrlEncodedContent(editData);

            client.PutAsync("http://localhost:20625/api/Tarjeta", content).ContinueWith(
                (putTask) =>
                {
                    putTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var delete = _tarjetaServicio.ObtenerPorId(id);
            return View(delete);
        }

        [HttpDelete]
        public ActionResult DeleteTarjeta(long id)
        {
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Tarjeta/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        private IEnumerable<TarjetaDto> GetFromApi()
        {
            try
            {
                var listaTarjeta = new List<TarjetaDto>();
                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Tarjeta").ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var leerDatos = result.Content.ReadAsAsync<List<TarjetaDto>>();
                        leerDatos.Wait();
                        listaTarjeta = leerDatos.Result;
                    }
                });

                obtenerDatos.Wait();
                return listaTarjeta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}