using System;
using System.Web.Mvc;
using PP.Servicio.Evento;
using PP.Servicio.TipoEvento;

namespace ApiConsummerMvc.Controllers
{
    public class HomeController: Controller
    {
        private readonly EventoServicio _eventoServicio;
        private readonly TipoEventoServicio _tipoEventoServicio;

        public HomeController()
        {
            _eventoServicio  = new EventoServicio();
            _tipoEventoServicio = new TipoEventoServicio();
        }

        public ActionResult Index()
        {
            var evetosCercanos = _eventoServicio.ObtenerCercanos(DateTime.Today);

            var tipoEvento = _tipoEventoServicio.Obtener(string.Empty);
            ViewBag.tipoevento = tipoEvento;
            return View(evetosCercanos);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}