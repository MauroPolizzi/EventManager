using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Banco;
using PP.Servicio.Banco;

namespace ApiConsummerMvc.Controllers
{
    public class BancoController : Controller
    {
        private readonly BancoServicio _bancoServicio;
        private readonly BancoRepositorio _bancoRepositorio;

        public BancoController()
        {
            _bancoServicio = new BancoServicio(_bancoRepositorio);
            _bancoRepositorio = new BancoRepositorio();
        }

        // GET: Banco
        public ActionResult Index()
        {
            var banco = GetFromApi();
            return View(banco);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BancoDto dto)
        {
            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", dto.Descripcion));;

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Banco", content).ContinueWith(
                (postTask =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                }));

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var edit = _bancoServicio.ObtenerPorId(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(BancoDto dto)
        {
            var client = new HttpClient();
            var editData = new List<KeyValuePair<string, string>>();
            editData.Add(new KeyValuePair<string, string>("Descripcion", dto.Descripcion));
            editData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            editData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            editData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));

            HttpContent content = new FormUrlEncodedContent(editData);

            client.PutAsync("http://localhost:20625/api/Banco", content).ContinueWith(
                (putTask) =>
                {
                    putTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var delete = _bancoServicio.ObtenerPorId(id);
            return View(delete);
        }

        [HttpDelete]
        public ActionResult DeleteBanco(long id)
        {
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Banco/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        private IEnumerable<BancoDto> GetFromApi()
        {
            try
            {
                var listaBanco = new List<BancoDto>();
                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Banco").ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var leerDatos = result.Content.ReadAsAsync<List<BancoDto>>();
                        leerDatos.Wait();
                        listaBanco = leerDatos.Result;
                    }
                });

                obtenerDatos.Wait();
                return listaBanco;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}