using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PP.Dominio.Enum;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Entrada;
using PP.IServicio.Factura;
using PP.Servicio.ClientePagina;
using PP.Servicio.Entrada;
using PP.Servicio.Evento;
using PP.Servicio.Factura;
using PP.Servicio.Usuario;
using PP.Servicio._01.Helpers;

namespace ApiConsummerMvc.Controllers
{
    public class EntradaController : Controller
    {
        private readonly EntradaServicio _entradaServicio;
        private readonly EventoServicio _eventoServicio;
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly ClientePaginaServicio _clientePaginaServicio;
        private readonly FacturaServicio _facturaServicio;


        public EntradaController()
        {
            _entradaServicio = new EntradaServicio();
            _eventoServicio = new EventoServicio();
            _usuarioRepositorio = new UsuarioRepositorio();
            _usuarioServicio = new UsuarioServicio(_usuarioRepositorio);
            _clientePaginaServicio = new ClientePaginaServicio();
            _facturaServicio = new FacturaServicio();

        }

        //=========================================// INDEX

        public ActionResult Index(long id)
        {
            var entradas = GetFromApi(id);
            ViewBag.eventoId = id;
            return View(entradas);
        }

        public ActionResult VentaEntrada(long id)
        {
            try
            {
                var evento = _eventoServicio.ObtenerPorId(id);
                ViewBag.nombreEvento = evento.Descripcion;

                var entrada = _entradaServicio.ObtenerPorEvento(id);

                List<TipoFormaPago> tipoFormaPago = Enum.GetValues(typeof(TipoFormaPago)).Cast<TipoFormaPago>().ToList();
                
                return View(entrada);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult VentaEntradaFactura(EntradaDto dto)
        {
            try
            {
                var entrada = _entradaServicio.ObtenerPorId(dto.Id);
                var evento = _eventoServicio.ObtenerPorId(entrada.EvetnoId);
                var usuario = _usuarioServicio.ObtenerPorId(Identidad.UsuarioLoginId);
                var cliente = _clientePaginaServicio.ObtenerPorId(usuario.ClienteId);


                var factura =new FacturaDto
                {
                    CantidadEntrada = dto.CantidadCompra,
                    ClienteId = Identidad.UsuarioLoginId,
                    Eliminado = false,
                    EntradaId = entrada.Id,
                    Fecha = DateTime.Today,
                    Monto = (dto.CantidadCompra * entrada.Precio),

                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    
                };
                
                _facturaServicio.Agregar(factura);

                return RedirectToAction("EventAll","Evento");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private IEnumerable<EntradaDto> GetFromApi(long eventoId)
        {
            try
            {
                var listaEntradas = new List<EntradaDto>();
                var client = new HttpClient();
                var obtenerDato = client.GetAsync("http://localhost:20625/api/Entrada")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<EntradaDto>>();
                            leerDatos.Wait();

                            foreach (var dto in leerDatos.Result)
                            {
                                if (dto.EvetnoId == eventoId)
                                {
                                    listaEntradas.Add(dto);
                                }
                            }
                        }
                    });

                obtenerDato.Wait();
                return listaEntradas;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        //=========================================// CRETE

        public ActionResult Create(long id)
        {
            try
            {
                ViewBag.eventoId = id;
                return View();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public ActionResult Crete(EntradaDto dto)
        {
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string,string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion",dto.Descripcion));
            postData.Add(new KeyValuePair<string, string>("NombreEntrada", dto.NombreEntrada));
            postData.Add(new KeyValuePair<string, string>("EventoId", $"{dto.EvetnoId}"));
            postData.Add(new KeyValuePair<string, string>("CantidadDisponible", $"{dto.CantidadDisponible}"));
            postData.Add(new KeyValuePair<string, string>("MaximoPermitido", $"{dto.MaximoPermitido}"));
            postData.Add(new KeyValuePair<string, string>("MinimoPermitido", $"{dto.MinimoPermitido}"));
            postData.Add(new KeyValuePair<string, string>("Precio", $"{dto.Precio}"));
            postData.Add(new KeyValuePair<string, string>("TipoEntrada", $"{dto.TipoEntrada}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PostAsync("http://localhost:20625/api/Entrada", content)
                .ContinueWith((postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Create","Ubicacion", new {id = dto.EvetnoId});
        }

        //=========================================// EDIT

        public ActionResult Edit(long id)
        {
            try
            {
                var entrada = _entradaServicio.ObtenerPorId(id);
                return View(entrada);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public ActionResult Edit(EntradaDto dto)
        {
            var client = new HttpClient();

            var putData = new List<KeyValuePair<string,string>>();
            putData.Add(new KeyValuePair<string, string>("Descripcion", dto.Descripcion));
            putData.Add(new KeyValuePair<string, string>("NombreEntrada", dto.NombreEntrada));
            putData.Add(new KeyValuePair<string, string>("EventoId", $"{dto.EvetnoId}"));
            putData.Add(new KeyValuePair<string, string>("CantidadDisponible", $"{dto.CantidadDisponible}"));
            putData.Add(new KeyValuePair<string, string>("MaximoPermitido", $"{dto.MaximoPermitido}"));
            putData.Add(new KeyValuePair<string, string>("MinimoPermitido", $"{dto.MinimoPermitido}"));
            putData.Add(new KeyValuePair<string, string>("Precio", $"{dto.Precio}"));
            putData.Add(new KeyValuePair<string, string>("TipoEntrada", $"{dto.TipoEntrada}"));
            putData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            putData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            putData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));

            HttpContent content = new FormUrlEncodedContent(putData);

            client.PutAsync("http://localhost:20625/api/Entrada", content)
                .ContinueWith((putTask) =>
                {
                    putTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", new {id = dto.EvetnoId});
        }

        //=========================================// EDIT

        public ActionResult Delete(long id)
        {
            try
            {
                var entrada = _entradaServicio.ObtenerPorId(id);
                return View(entrada);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult DeleteEntrada(long id)
        {
            var entrada = _entradaServicio.ObtenerPorId(id);

            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Entrada/{id}")
                .ContinueWith((deleteTask) =>
                {
                    deleteTask.Result.EnsureSuccessStatusCode();
                });

            return RedirectToAction("Index", new {id = entrada.EvetnoId});
        }
    }
}