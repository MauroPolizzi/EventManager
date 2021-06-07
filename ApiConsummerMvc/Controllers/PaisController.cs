using PP.IServicio.Pais;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.Servicio.Pais;
using PP.Servicio.Provincia;

namespace ApiConsummerMvc.Controllers
{
    public class PaisController : Controller
    {
        private readonly PaisRepositorio _ipaisrepositorio;
        private readonly PaisServicio _paisServicio;

        private readonly ProvinciaRepositorio _provinciaRepositorio;
        private readonly ProvinciaServicio _provinciaServicio;

        public PaisController()
        {
            _ipaisrepositorio = new PaisRepositorio();
            _paisServicio = new PaisServicio(_ipaisrepositorio);
            _provinciaRepositorio = new ProvinciaRepositorio();
            _provinciaServicio = new ProvinciaServicio(_provinciaRepositorio);
        }

        //=========================================// INDEX

        public ActionResult Index()
        {
            var paises = GetFromApi();
            return View(paises);
        }

        //=========================================// CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaisDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Pais", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        //=========================================// EDIT
        public ActionResult Edit(long id)
        {
            var pais =_paisServicio.ObtenerPorId(id);
            return View(pais);
        }

        [HttpPost]
        public ActionResult Edit(PaisDto dto)
        {
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PutAsync("http://localhost:20625/api/Pais", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            //_paisServicio.Modificar(dto);
            return RedirectToAction("Index");
        }

        //=========================================// DELETE
        public ActionResult Delete(long id)
        {
            var pais =_paisServicio.ObtenerPorId(id);
            return View(pais);
        }

        [HttpPost]
        public ActionResult DeletePais(long id)
        {
            var client = new HttpClient();
            
            client.DeleteAsync($"http://localhost:20625/api/Pais/{id}").ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });
            //_paisServicio.Eliminar(id);
            return RedirectToAction("Index");
        }
        
        //=========================================//
        private IEnumerable<PaisDto> GetFromApi()
        {
            try
            {
                var listaPaises = new List<PaisDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Pais")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<PaisDto>>();
                            leerDatos.Wait();

                            listaPaises = leerDatos.Result;
                        }
                    });

                obtenerDatos.Wait();
                return listaPaises;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}