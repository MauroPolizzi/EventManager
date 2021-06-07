using System;
using System.Web.Mvc;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Factura;
using PP.Servicio.ClientePagina;
using PP.Servicio.Entrada;
using PP.Servicio.Evento;
using PP.Servicio.Factura;
using PP.Servicio.Usuario;
using PP.Servicio._01.Helpers;

namespace ApiConsummerMvc.Controllers
{
    public class FacturaController : Controller
    {
        private readonly EntradaServicio _entradaServicio;
        private readonly EventoServicio _eventoServicio;
        private readonly FacturaServicio _facturaServicio;
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly ClientePaginaServicio _clientePaginaServicio;
        

        public FacturaController()
        {
            _entradaServicio = new EntradaServicio();
            _eventoServicio = new EventoServicio();
            _facturaServicio = new FacturaServicio();
            _usuarioRepositorio = new UsuarioRepositorio();
            _usuarioServicio = new UsuarioServicio(_usuarioRepositorio);
            _clientePaginaServicio = new ClientePaginaServicio();
        }

        // GET: Factura
        public ActionResult Index()
        {
            try
            {
                var facturas = _facturaServicio.Obtener(string.Empty);
                return View(facturas);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public ActionResult Create(FacturaDto dto)
        {
            try
            {
                _facturaServicio.Agregar(dto);

                return RedirectToAction("EventAll", "Evento");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Detail(long id)
        {
            try
            {
                var factura = _facturaServicio.ObtenerPorId(id);

                var entrada = _entradaServicio.ObtenerPorId(factura.EntradaId);
                var usiario = _usuarioServicio.ObtenerPorId(factura.ClienteId);
                var cliente = _clientePaginaServicio.ObtenerPorId(usiario.ClienteId);
                var evento = _eventoServicio.ObtenerPorId(entrada.EvetnoId);

                //var proxNumFactura = _facturaServicio.SiguienteNum();

                var fac = new FacturaDto
                {
                    CantidadEntrada = factura.CantidadEntrada,
                    ClienteId = Identidad.UsuarioLoginId,
                    Eliminado = false,
                    EntradaId = entrada.Id,
                    Fecha = DateTime.Today,
                    Monto = (factura.CantidadEntrada* entrada.Precio),
                    NumeroFactura = factura.NumeroFactura,
                    Id = factura.Id,

                    PrecioEntrada = entrada.Precio,
                    
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                };
                return View(fac);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}