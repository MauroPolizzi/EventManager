using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Factura;

namespace PP.Servicio.Factura
{
    public class FacturaServicio : IFacturaServicio
    {
        private readonly FacturaRepositorio _facturaRepositorio;

        public FacturaServicio()
            : this(new FacturaRepositorio())
        {

        }

        public FacturaServicio(FacturaRepositorio facturaRepositorio)
        {
            _facturaRepositorio = facturaRepositorio ;
        }
        public void Agregar(FacturaDto dto)
        {
            var proxNum = SiguienteNum();

            var factura = new Dominio.Entidades.Factura
            {
                CantidadEntrada = dto.CantidadEntrada,
                UsuarioId = dto.ClienteId,
                Eliminado = dto.Eliminado,
                EntradaId = dto.EntradaId,
                Fecha = dto.Fecha,
                
                Monto = dto.Monto,
                NumeroFactura = proxNum,
            };

            _facturaRepositorio.Add(factura);
            _facturaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var factura = _facturaRepositorio.GetById(id);

            _facturaRepositorio.UpDate(factura);

            factura.Eliminado = !factura.Eliminado;

            _facturaRepositorio.Save();
        }

        public void Modificar(FacturaDto dto)
        {

        }

        public IEnumerable<FacturaDto> Obtener(string cadenaBuscar)
        {
            return _facturaRepositorio.GetAll().Where(x => x.Eliminado == false).Select(x => new FacturaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                CantidadEntrada = x.CantidadEntrada,
                ClienteId = x.UsuarioId,
                Eliminado = x.Eliminado,
                EntradaId = x.EntradaId,
                Fecha = x.Fecha,
                Monto = x.Monto,
                NumeroFactura = x.NumeroFactura,
            }).ToList();
        }

        public IEnumerable<FacturaDto> ObtenerPorCliente(string cadenaBuscar, long clienteId)
        {
            return _facturaRepositorio.GetAll().Where(x => x.Eliminado == false
            && x.UsuarioId == clienteId).Select(x => new FacturaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                CantidadEntrada = x.CantidadEntrada,
                ClienteId = x.UsuarioId,
                Eliminado = x.Eliminado,
                EntradaId = x.EntradaId,
                Fecha = x.Fecha,
                Monto = x.Monto,
                NumeroFactura = x.NumeroFactura,
            }).ToList();
        }
        public IEnumerable<FacturaDto> ObtenerPorEntrada(string cadenaBuscar, long entradaId)
        {
            return _facturaRepositorio.GetAll().Where(x => x.Eliminado == false
                                                           && x.UsuarioId == entradaId).Select(x => new FacturaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                CantidadEntrada = x.CantidadEntrada,
                ClienteId = x.UsuarioId,
                Eliminado = x.Eliminado,
                EntradaId = x.EntradaId,
                Fecha = x.Fecha,
                Monto = x.Monto,
                NumeroFactura = x.NumeroFactura,
            }).ToList();
        }

        public FacturaDto ObtenerPorId(long id)
        {
            var factura = _facturaRepositorio.GetById(id);

            return new FacturaDto
            {
                Id = factura.Id,
                RowVersion = factura.RowVersion,
                CantidadEntrada = factura.CantidadEntrada,
                ClienteId = factura.UsuarioId,
                Eliminado = factura.Eliminado,
                EntradaId = factura.EntradaId,
                Fecha = factura.Fecha,
                Monto = factura.Monto,
                NumeroFactura = factura.NumeroFactura,
            };
        }

        public int SiguienteNum()
        {
            return _facturaRepositorio.GetAll().Any()
                ? _facturaRepositorio.GetAll().Max(x => x.NumeroFactura) + 1
                : 1;
        }
    }
}
