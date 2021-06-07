using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Localidad;
using PP.IServicio.Provincia;
using PP.Servicio.Localidad;
using PP.Servicio.Provincia;

namespace ApiConsummerMvc.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly ProvinciaRepositorio _provinciaRepositorio;
        private readonly ProvinciaServicio _provinciaServicio;
        private readonly LocalidadRepositorio _localidadRepositorio;
        private readonly LocalidadServicio _localidadServicio;

        public LocalidadController()
        {
            _provinciaRepositorio = new ProvinciaRepositorio();
            _provinciaServicio = new ProvinciaServicio(_provinciaRepositorio);
            _localidadRepositorio = new LocalidadRepositorio();
            _localidadServicio = new LocalidadServicio(_localidadRepositorio);
        }

        //=========================================// INDEX

        public ActionResult Index(long id)
        {
            var localidades = ObtenerPorApi(id);
            ViewBag.provinciaId = id;
            return View(localidades);
        }

        private List<LocalidadDto> ObtenerPorApi(long provId)
        {
            try
            {
                var listaLocalidades = new List<LocalidadDto>();

                var client = new HttpClient();

                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Localidad")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<LocalidadDto>>();
                            leerDatos.Wait();

                            foreach (var localidad in leerDatos.Result)
                            {
                                if (localidad.ProvinciaId == provId)
                                {
                                    listaLocalidades.Add(localidad);
                                }
                            }
                        }
                    });
                obtenerDatos.Wait();
                return listaLocalidades;

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
            var provincias = _provinciaServicio.Obtener(string.Empty);
            ViewBag.provinciaId = id;
            ViewBag.provincias = new SelectList(provincias,"Id","Descripcion","ProvinciaId");
            return View();
        }

        [HttpPost]
        public ActionResult Create(LocalidadDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClient();
                var postData = new List<KeyValuePair<string,string>>();
                postData.Add(new KeyValuePair<string, string>("Descripcion",$"{dto.Descripcion}"));
                postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
                postData.Add(new KeyValuePair<string, string>("ProvinciaId", $"{dto.ProvinciaId}"));
                postData.Add(new KeyValuePair<string, string>("CodigoPostal", $"{dto.CodigoPostal}"));

                var content = new FormUrlEncodedContent(postData);

                client.PostAsync("http://localhost:20625/api/Localidad", content).ContinueWith(
                    (postTask) =>
                    {
                        postTask.Result.EnsureSuccessStatusCode();
                    });

                return RedirectToAction("Index","Localidad",new {id= dto.ProvinciaId});
            }
            catch
            {
                return View();
            }
        }

        //=========================================// EDIT

        public ActionResult Edit(int id)
        {
            var localidad = _localidadServicio.ObtenerPorId(id);
            return View(localidad);
        }
        
        [HttpPost]
        public ActionResult Edit(LocalidadDto dto)
        {
            try
            {
                // TODO: Add update logic here
                var client = new HttpClient();
                var putData = new List<KeyValuePair<string,string>>();
                putData.Add(new KeyValuePair<string, string>("Descripcion",$"{dto.Descripcion}"));
                putData.Add(new KeyValuePair<string, string>("CodigoPostal", $"{dto.CodigoPostal}"));
                putData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
                putData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
                putData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
                putData.Add(new KeyValuePair<string, string>("ProvinciaId", $"{dto.ProvinciaId}"));

                var content = new FormUrlEncodedContent(putData);

                client.PutAsync("http://localhost:20625/api/Localidad", content).ContinueWith(
                    (putTask) =>
                    {
                        putTask.Result.EnsureSuccessStatusCode();

                    });

                return RedirectToAction("Index","Localidad",new {id= dto.ProvinciaId});
            }
            catch
            {
                return View();
            }
        }

        //=========================================// DELETE

        public ActionResult Delete(long id)
        {
            var localidad = _localidadServicio.ObtenerPorId(id);
            return View(localidad);
        }

        [HttpPost]
        public ActionResult DeleteLocalidad(long id)
        {
            var localidad = ObtenerLocalidad(id);

            // TODO: Add delete logic here
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Pais/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", "Localidad",new {id = localidad.ProvinciaId});
        }

        private LocalidadDto ObtenerLocalidad(long id)
        {
            try
            {
                var localidad = new LocalidadDto();

                var client = new HttpClient();

                var obtenerDato = client.GetAsync($"http://localhost:20625/api/Localidad/{id}")
                    .ContinueWith((getTask) =>
                    {
                        var resultado = getTask.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<LocalidadDto>();
                            leerDatos.Wait();

                            localidad = leerDatos.Result;
                        }
                    });
                obtenerDato.Wait();
                return localidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
