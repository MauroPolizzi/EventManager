using PP.InfraestructuraRepositorio;
using System.Web.Mvc;
using PP.IServicio.Provincia;
using PP.Servicio.Provincia;
using System.Net.Http;
using System.Collections.Generic;
using System;
using System.Net;
using PP.Servicio.Localidad;
using PP.Servicio.Pais;

namespace ApiConsummerMvc.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly ProvinciaRepositorio _provinciaRepositorio;
        private readonly PaisRepositorio _paisRepositorio;
        private readonly PaisServicio _paisServicio;
        private readonly ProvinciaServicio _provinciaServicio;

        public ProvinciaController()
        {
            _paisRepositorio = new PaisRepositorio();
            _paisServicio = new PaisServicio(_paisRepositorio);
            _provinciaRepositorio = new ProvinciaRepositorio();
            _provinciaServicio = new ProvinciaServicio(_provinciaRepositorio);
        }

        //=========================================// INDEX

        public ActionResult Index(long id)
        {
            var provincias = GetFromApi(id);
            ViewBag.paisId = id;
            return View(provincias);
        }

        private IEnumerable<ProvinciaDto> GetFromApi(long paisId)
        {
            try
            {
                var listaProvincias = new List<ProvinciaDto>();
                var client = new HttpClient();

                var obtenerDato = client.GetAsync("http://localhost:20625/api/Provincia")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerResultado = resultado.Content.ReadAsAsync<List<ProvinciaDto>>();
                            leerResultado.Wait();

                            foreach (var prov in leerResultado.Result)
                            {
                                if (prov.PaisId == paisId)
                                {
                                    listaProvincias.Add(prov);
                                }
                            }
                        }
                    });
                obtenerDato.Wait();
                return listaProvincias;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //=========================================// CREATE

        public ActionResult Create(long id)
        {
                var paises = _paisServicio.Obtener(string.Empty);

                ViewBag.paisId = id;
                ViewBag.Paises = new SelectList(paises, "Id", "Descripcion");
             
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProvinciaDto dto)
        {
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion",$"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("PaisId",$"{dto.PaisId}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Provincia", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index","Provincia", new {id = dto.PaisId});
        }

        //=========================================// DELETE

        public ActionResult Delete(long id)
        {
            var prov = _provinciaServicio.ObtenerPorId(id);
            return View(prov);
        }

        [HttpPost]
        public ActionResult DeleteProv(long id)
        {
            var provincia = ObtenerProvApi(id);

            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Provincia/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });
            return RedirectToAction("Index", "Provincia",new {id = provincia.PaisId});
        }

        private ProvinciaDto ObtenerProvApi(long provinciaId)
        {
            try
            {
                var provincia = new ProvinciaDto();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync($"http://localhost:20625/api/Provincia/{provinciaId}")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<ProvinciaDto>();
                            leerDatos.Wait();

                            provincia = leerDatos.Result;
                        }
                    });

                obtenerDatos.Wait();
                return provincia;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //=========================================// EDIT

        public ActionResult Edit(long id)
        {
            var provincia = _provinciaServicio.ObtenerPorId(id);
            return View(provincia);
        }

        [HttpPost]
        public ActionResult Edit(ProvinciaDto dto)
        {
            var client = new HttpClient();
            
            var putData = new List<KeyValuePair<string,string>>();
            putData.Add(new KeyValuePair<string, string>("Descripcion",$"{dto.Descripcion}"));
            putData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            putData.Add(new KeyValuePair<string, string>("Elimiando", $"{dto.Eliminado}"));
            putData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
            putData.Add(new KeyValuePair<string, string>("PaisId", $"{dto.PaisId}"));

            var content = new FormUrlEncodedContent(putData);

            client.PutAsync($"http://localhost:20625/api/Provincia", content).ContinueWith(
                (putTask) =>
                {
                    putTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", "Provincia",new {id = dto.PaisId});
        }
        
    }
}