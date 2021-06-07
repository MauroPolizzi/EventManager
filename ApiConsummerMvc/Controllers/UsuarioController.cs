using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Usuario;
using PP.Servicio.Usuario;
using PP.Servicio._01.Helpers;

namespace ApiConsummerMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioServicio _usuarioServicio;
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private int contador;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            _usuarioServicio = new UsuarioServicio(_usuarioRepositorio);
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = GetFromApi();
            return View(usuario);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult InicioSecion()
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
        public ActionResult InicioSecion(UsuarioDto dto)
        {
            try
            {
                if (_usuarioServicio.VerificarSiExiste(dto.NombreUsuario, dto.Password)) // 
                {
                    var usu = _usuarioServicio.ObtenerPorNombre(dto.NombreUsuario, dto.Password);

                    if (usu.EstaBloqueado == false)
                    {
                        Identidad.UsuarioLogin = dto.NombreUsuario;
                        Identidad.UsuarioLoginId = usu.Id;


                        return RedirectToAction("EventAll", "Evento");
                    }
                    else
                    {
                        ViewBag.bloqueado = "El usuario esta Bloqueado";
                        return View();
                    }

                }
                else
                {
                    contador++;
                    if (contador == 3)
                    {
                        ViewBag.Bloqueado = "El usuario se Bloqueo";
                        contador = 0;
                    }
                    return View();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public ActionResult CerrarSesion(UsuarioDto dto)
        {
            try
            {
                if (_usuarioServicio.VerificarSiExiste(dto.NombreUsuario, dto.Password)) // 
                {
                    var usu = _usuarioServicio.ObtenerPorNombre(dto.NombreUsuario, dto.Password);

                    if (usu.EstaBloqueado == false)
                    {
                        Identidad.UsuarioLogin = null;
                        Identidad.UsuarioLoginId = dto.Id;


                        return RedirectToAction("EventAll", "Evento");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult Create(UsuarioDto dto)
        {
            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("NombreUsuario", dto.NombreUsuario));
            postData.Add(new KeyValuePair<string, string>("Password", dto.Password));
            postData.Add(new KeyValuePair<string, string>("ClienteId", $"{dto.EstaBloqueado}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Usuario", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var edit = _usuarioServicio.ObtenerPorId(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioDto dto)
        {
            var client = new HttpClient();
            var editData = new List<KeyValuePair<string, string>>();
            editData.Add(new KeyValuePair<string, string>("id", $"{dto.Id}"));
            editData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
            editData.Add(new KeyValuePair<string, string>("NombreUsuario", dto.NombreUsuario));
            editData.Add(new KeyValuePair<string, string>("Password", dto.Password));
            editData.Add(new KeyValuePair<string, string>("ClienteId", $"{dto.ClienteId}"));
            editData.Add(new KeyValuePair<string, string>("EstaBloqueado", $"{dto.EstaBloqueado}"));

            HttpContent content = new FormUrlEncodedContent(editData);

            client.PutAsync("http://localhost:20625/api/Usuario", content).ContinueWith(
                (putTask) =>
                {
                    putTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var delete = _usuarioServicio.ObtenerPorId(id);
            return View(delete);
        }

        [HttpDelete]
        public ActionResult DeleteUsuario(long id)
        {
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Usuario/{id}").ContinueWith(
                (deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index");
        }

        private IEnumerable<UsuarioDto> GetFromApi()
        {
            try
            {
                var listaUsuario = new List<UsuarioDto>();
                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Usuario").ContinueWith(response =>
                {
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var leerDatos = result.Content.ReadAsAsync<List<UsuarioDto>>();
                        leerDatos.Wait();
                        listaUsuario = leerDatos.Result;
                    }
                });

                obtenerDatos.Wait();
                return listaUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}