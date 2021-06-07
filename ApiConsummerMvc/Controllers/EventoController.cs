using PP.InfraestructuraRepositorio;
using PP.IServicio.Evento;
using PP.Servicio.Evento;
using PP.Servicio.PreguntaFrecuente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PP.Servicio.Entrada;
using PP.Servicio.Localidad;
using PP.Servicio.Pais;
using PP.Servicio.Provincia;
using PP.Servicio.Ubicacion;
using PP.Servicio.FechaEvento;
using PP.Servicio.TipoEvento;
using PP.Dominio.Enum;
using System.Web.UI.WebControls;
using PP.Servicio._01.Helpers;

namespace ApiConsummerMvc.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        private readonly EventoServicio _eventoServicio;
        private readonly PreguntaFrecuenteRepositorio _preguntaRepositorio;
        private readonly PreguntaFrecuenteServicio _preguntaServicio;

        private readonly PaisServicio _paisServicio;
        private readonly ProvinciaServicio _provinciaServicio;
        private readonly LocalidadServicio _localidadServicio;

        private readonly UbicacionServicio _ubicacionservicio;
        private readonly FechaEventoServicio _fechaeventoservicio;
        private readonly EntradaServicio _entradaServicio;

        private readonly TipoEventoServicio _tipoEventoServicio;
        private readonly TipoEventoRepositorio _tipoEventoRepo;

        public EventoController()
        {
            _eventoServicio = new EventoServicio();
            _preguntaRepositorio = new PreguntaFrecuenteRepositorio();
            _preguntaServicio = new PreguntaFrecuenteServicio(_preguntaRepositorio);
            _paisServicio = new PaisServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();
            _ubicacionservicio = new UbicacionServicio();
            _fechaeventoservicio = new FechaEventoServicio();
            _entradaServicio = new EntradaServicio();
            _tipoEventoRepo = new TipoEventoRepositorio();
            _tipoEventoServicio = new TipoEventoServicio(_tipoEventoRepo);
        }

        // GET: Evento
        public ActionResult Index()
        {
            try
            {
                var eventos = GetFromApi();
                return View(eventos);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Create()
        {
            try
            {
                var pais = _paisServicio.Obtener(string.Empty);
                ViewBag.pais = new SelectList(pais, "Id", "Descripcion");
                var provincia = _provinciaServicio.Obtener(string.Empty);
                ViewBag.provincia = new SelectList(provincia, "Id", "Descripcion");
                var localidad = _localidadServicio.Obtener(string.Empty);
                ViewBag.localidad = new SelectList(localidad, "Id", "Descripcion");

                List<TipoEntrada> listTipoEntrada = Enum.GetValues(typeof(TipoEntrada)).Cast<TipoEntrada>().ToList();

                ViewBag.tipoEntrada = new SelectList(listTipoEntrada,"Value");

                var tipoEvento = _tipoEventoServicio.Obtener("");
                ViewBag.comboTipoEvento = new SelectList(tipoEvento, "Id", "Descripcion");
                return View();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult Create(EventoDetailDto dto)
        {
            try
            {
                var pic = string.Empty;
                var folder = "~/Content/ImagenEvento";
                if(dto.ImagenFile != null)
                {
                    
                    pic = Helpers.CrearImagen.UploadImagen(dto.ImagenFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                dto.Imagen = pic;
                
                 
                //var client = new HttpClient();

                //// This is the postdata
                //var postData = new List<KeyValuePair<string, string>>();
                //postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
                //postData.Add(new KeyValuePair<string, string>("ApellidoOrganizador", $"{dto.ApellidoOrganizador}"));
                //postData.Add(new KeyValuePair<string, string>("Email", $"{dto.Email}"));
                //postData.Add(new KeyValuePair<string, string>("Facebook", $"{dto.Facebook}"));
                //postData.Add(new KeyValuePair<string, string>("Imagen", $"{dto.Imagen}"));
                //postData.Add(new KeyValuePair<string, string>("InformacionAdicional", $"{dto.InformacionAdicional}"));
                //postData.Add(new KeyValuePair<string, string>("Nombre", $"{dto.Nombre}"));
                //postData.Add(new KeyValuePair<string, string>("NombreOrganizador", $"{dto.NombreOrganizador}"));
                //postData.Add(new KeyValuePair<string, string>("Twitter", $"{dto.Twitter}"));
                //HttpContent content = new FormUrlEncodedContent(postData);

                //client.PostAsync("http://localhost:20625/api/Evento", content).ContinueWith(
                //    (postTask) =>
                //    {
                //        postTask.Result.EnsureSuccessStatusCode();
                //    });

                _eventoServicio.Agregar(dto);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                var evento = _eventoServicio.ObtenerPorId(id);

                return View(evento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult Edit(EventoDto dto)
        {
            var pic = string.Empty;
            var folder = "~/Content/ImagenEvento";
            if (dto.ImagenFile != null)
            {

                pic = Helpers.CrearImagen.UploadImagen(dto.ImagenFile, folder);
                pic = string.Format("{0}/{1}", folder, pic);
                dto.Imagen = pic;
            }

            
            var client = new HttpClient();

            // This is the postdata
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Descripcion", $"{dto.Descripcion}"));
            postData.Add(new KeyValuePair<string, string>("Id", $"{dto.Id}"));
            postData.Add(new KeyValuePair<string, string>("Eliminado", $"{dto.Eliminado}"));
            postData.Add(new KeyValuePair<string, string>("RowVersion", $"{dto.RowVersion}"));
            postData.Add(new KeyValuePair<string, string>("ApellidoOrganizador", $"{dto.ApellidoOrganizador}"));
            postData.Add(new KeyValuePair<string, string>("Email", $"{dto.Email}"));
            postData.Add(new KeyValuePair<string, string>("Facebook", $"{dto.Facebook}"));
            postData.Add(new KeyValuePair<string, string>("Imagen", $"{dto.Imagen}"));
            postData.Add(new KeyValuePair<string, string>("InformacionAdicional", $"{dto.InformacionAdicional}"));
            postData.Add(new KeyValuePair<string, string>("Nombre", $"{dto.Nombre}"));
            postData.Add(new KeyValuePair<string, string>("NombreOrganizador", $"{dto.NombreOrganizador}"));
            postData.Add(new KeyValuePair<string, string>("Twitter", $"{dto.Twitter}"));

            HttpContent content = new FormUrlEncodedContent(postData);

            client.PutAsync("http://localhost:20625/api/Evento", content).ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });


            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            try
            {
                var evento = _eventoServicio.ObtenerPorId(id);
                return View(evento);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult DeleteEvento(long id)
        {
            var client = new HttpClient();

            client.DeleteAsync($"http://localhost:20625/api/Evento/{id}").ContinueWith(
                (postTask) =>
                {
                    postTask.Result.EnsureSuccessStatusCode();
                });
            //_paisServicio.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(long id)
        {
            try
            {
                
                
                    var ubicacion = _ubicacionservicio.ObtenerPorEvento(id);
                    //ViewBag.ubicacion = ubicacion.PrimDireccion;
                    var fecha = _fechaeventoservicio.ObtenerPorEvento(id);
                    //ViewBag.fechaDesde = fecha.FechaDesde;
                    //ViewBag.horaDesde = fecha.HoraDesde;
                    var entrada = _entradaServicio.ObtenerPorEvento(id);
                    //ViewBag.entrada = entrada.CantidadDisponible;
                    //ViewBag.entradaPrecio = entrada.Precio;
                    var localidad = _localidadServicio.ObtenerPorId(ubicacion.LocalidadId);

                    var evento = _eventoServicio.ObtenerPorId(id);
                    ViewBag.EventoId = id;
                    var TEvento = _tipoEventoServicio.ObtenerPorId(evento.TipoEventoId);
                    //ViewBag.tipoEvento = TEvento.Descripcion;

                    EventoDetailDto eventoDetalle = new EventoDetailDto
                    {
                        //--------- Evento -----------//
                        Nombre = evento.Nombre,
                        Descripcion = evento.Descripcion,
                        Imagen = evento.Imagen,
                        ApellidoOrganizador = evento.ApellidoOrganizador,
                        NombreOrganizador = evento.NombreOrganizador,
                        Email = evento.Email,
                        InformacionAdicional = evento.InformacionAdicional,
                        Twitter = evento.Twitter,
                        Facebook = evento.Facebook,

                        //--------- Fecha -----------//
                        FechaDesde = fecha.FechaDesde,
                        FechaHasta = fecha.FechaHasta,
                        HoraDesde = fecha.HoraDesde,
                        HoraHasta = fecha.HoraHasta,

                        //--------- Ubicacion -----------//
                        NombreEstablecimiento = ubicacion.NombreEstablecimiento,
                        LocalidadDescripcion = localidad.Descripcion,
                        PrimDireccion = ubicacion.PrimDireccion,
                        SegDireccion = ubicacion.SegDireccion,

                        //--------- Entrada -----------//
                        NombreEntrada = entrada.NombreEntrada,
                        DescripcionEntrada = entrada.Descripcion,
                        CantidadDisponible = entrada.CantidadDisponible,
                        MaximoPermitido = entrada.MaximoPermitido,
                        MinimoPermitido = entrada.MinimoPermitido,
                        Precio = entrada.Precio,
                        TipoEntrada = entrada.TipoEntrada,


                        TipoEventoDescripcion = TEvento.Descripcion,
                    };

                    return View(eventoDetalle);
                
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ActionResult EventAll()
        {
            try
            {
                var eventos = _eventoServicio.Obtener(string.Empty);

                var tipoevento = _tipoEventoServicio.Obtener(string.Empty);
                ViewBag.tipoevento = tipoevento;
                return View(eventos);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ActionResult EventAllForType(long id)
        {
            try
            {
                var tipoevento = _tipoEventoServicio.Obtener(string.Empty);
                ViewBag.tipoevento = tipoevento;

                var eventoTipo = _eventoServicio.ObtenerPorTipo(id);
                
                return View(eventoTipo);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        private IEnumerable<EventoDto> GetFromApi()
        {
            try
            {
                var listaPaises = new List<EventoDto>();

                var client = new HttpClient();
                var obtenerDatos = client.GetAsync("http://localhost:20625/api/Evento")
                    .ContinueWith(response =>
                    {
                        var resultado = response.Result;
                        if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var leerDatos = resultado.Content.ReadAsAsync<List<EventoDto>>();
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