using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.PaginaCliente;
using PP.Servicio.ClientePagina;
using PP.Servicio.Usuario;

namespace ApiConsummerMvc.Controllers
{
    public class ClientePaginaController : Controller
    {
        private readonly ClientePaginaServicio _clientePaginaServicio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public ClientePaginaController()
        {
            _clientePaginaServicio = new ClientePaginaServicio();
            _usuarioRepositorio = new UsuarioRepositorio();
            _usuarioServicio = new UsuarioServicio(_usuarioRepositorio);
        }

        // GET: ClientePagina
        public ActionResult Index()
        {
            var clientePagina = GetFromApi();
            return View(clientePagina);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientePaginaDto dto)
        {
            try
            {
                //var client = new HttpClient();
                //var postData = new List<KeyValuePair<string, string>>();
                //postData.Add(new KeyValuePair<string, string>("Nombre", dto.Nombre));
                //postData.Add(new KeyValuePair<string, string>("Apellido", dto.Apellido));
                //postData.Add(new KeyValuePair<string, string>("Telefono", dto.Telefono));
                //postData.Add(new KeyValuePair<string, string>("Celular ", dto.Celular));
                //postData.Add(new KeyValuePair<string, string>("Email", dto.Email));
                //postData.Add(new KeyValuePair<string, string>("Domicilio", dto.Domicilio));

                //HttpContent content = new FormUrlEncodedContent(postData);

                //client.PostAsync("http://localhost:20625/api/ClientePagina", content).ContinueWith(
                //    (postTask) =>
                //    {
                //        postTask.Result.EnsureSuccessStatusCode();
                //    });

                _clientePaginaServicio.Agregar(dto);

                

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Edit(long id)
        {
            var edit = _clientePaginaServicio.ObtenerPorId(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(ClientePaginaDto dto)
        {
            try
            {
                var client = new HttpClient();
                var editData = new List<KeyValuePair<string, string>>();
                editData.Add(new KeyValuePair<string, string>("id", $"{dto.Id}"));
                editData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
                editData.Add(new KeyValuePair<string, string>("Nombre", dto.Nombre));
                editData.Add(new KeyValuePair<string, string>("Apellido", dto.Apellido));
                editData.Add(new KeyValuePair<string, string>("Nombre", dto.Telefono));
                editData.Add(new KeyValuePair<string, string>("Celular", dto.Celular));
                editData.Add(new KeyValuePair<string, string>("Email", dto.Email));
                editData.Add(new KeyValuePair<string, string>("Domicilio", dto.Domicilio));

                HttpContent content = new FormUrlEncodedContent(editData);

                client.PutAsync("http://localhost:20625/api/ClientePagina", content).ContinueWith(
                    (putTask) =>
                    {
                        putTask.Result.EnsureSuccessStatusCode();
                    });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Delete(long id)
        {
            var delete = _clientePaginaServicio.ObtenerPorId(id);
            return View(delete);
        }

        [HttpDelete]
        public ActionResult DeleteClientePagina(long id)
        {
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/ClientePagina/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        private IEnumerable<ClientePaginaDto> GetFromApi()
        {
            try
            {
                var listaCliente = new List<ClientePaginaDto>();
                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/ClientePagina").ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var leerDatos = result.Content.ReadAsAsync<List<ClientePaginaDto>>();
                        leerDatos.Wait();
                        listaCliente = leerDatos.Result;
                    }
                });

                obtenerDatos.Wait();
                return listaCliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}