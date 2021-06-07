using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Detalle;

namespace PP.Servicio.Detalle
{
    public class DetalleServicio : IDetalleServicio
    {
        private readonly DetalleRepositorio _detalleRepositorio;

        public DetalleServicio()
            :this(new DetalleRepositorio())
        {
            
        }

        public DetalleServicio(DetalleRepositorio detalleRepositorio)
        {
            _detalleRepositorio = detalleRepositorio;
        }
        public void Agregar(DetalleDto dto)
        {
            var detalle = new Dominio.Entidades.Detalle
            {
                Cantidad = dto.Cantidad,
                Costo = dto.Costo,
                FacturaId = dto.FacturaId,
                SubTotal = dto.SubTotal,
                Total = dto.Total
            };

            _detalleRepositorio.Add(detalle);
            _detalleRepositorio.Save();
        }

        public void Eliminar(long id)
        {

        }

        public void Modificar(DetalleDto dto)
        {
            
        }

        public IEnumerable<DetalleDto> Obtener(string cadenaBuscar)
        {
            return _detalleRepositorio.GetAll().Select(x => new DetalleDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Cantidad = x.Cantidad,
                Costo = x.Costo,
                FacturaId = x.FacturaId,
                SubTotal = x.SubTotal,
                Total = x.Total
            }).ToList();
        }
        public IEnumerable<DetalleDto> ObtenerPorFactura(string cadenaBuscar, long facturaId)
        {
            return _detalleRepositorio.GetAll().Where(x => x.FacturaId == facturaId).Select(x => new DetalleDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Cantidad = x.Cantidad,
                Costo = x.Costo,
                FacturaId = x.FacturaId,
                SubTotal = x.SubTotal,
                Total = x.Total
            }).ToList();
        }

        public DetalleDto ObtenerPorId(long id)
        {
            var factura = _detalleRepositorio.GetById(id);

            return new DetalleDto
            {
                Id = factura.Id,
                RowVersion = factura.RowVersion,
                Cantidad = factura.Cantidad,
                Costo = factura.Costo,
                FacturaId = factura.FacturaId,
                SubTotal = factura.SubTotal,
                Total = factura.Total
            };
        }
    }
}
