using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Dominio.Repositorio.FormaPago;
using PP.IServicio.FormaPago;

namespace PP.Servicio.FormaPago
{
    public class FormaPagoServicio : IFormaPagoServicio
    {
        private readonly IFormaPagoRepositorio _formaPagoRepositorio;

        public FormaPagoServicio(IFormaPagoRepositorio formaPagoRepositorio)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
        }

        public void Agregar(FormaPagoDto dto)
        {
            var formaPago = new Dominio.Entidades.FormaPago
            {
                Monto = dto.Monto,
                FaturaId = dto.EntradaId, // Confusion en el nombre de facturaId en la entidad. Revisar el modelo
                TipoFormaPago = dto.TipoFormaPago
            };

            _formaPagoRepositorio.Add(formaPago);
            _formaPagoRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var formaPago = _formaPagoRepositorio.GetById(id);

            _formaPagoRepositorio.Delete(id);
            _formaPagoRepositorio.Save();
        }

        public void Guardar()
        {
            _formaPagoRepositorio.Save();
        }

        public void Modificar(FormaPagoDto dto)
        {
            var formaPago = _formaPagoRepositorio.GetById(dto.Id);

            _formaPagoRepositorio.UpDate(formaPago);
            
            formaPago.Monto = dto.Monto;
            formaPago.FaturaId = dto.EntradaId;
            formaPago.TipoFormaPago = dto.TipoFormaPago;

            _formaPagoRepositorio.Save();
        }

        public IEnumerable<FormaPagoDto> Obtener(string cadenaBuscar)
        {
            return _formaPagoRepositorio.GetAll()
                .Select(x => new FormaPagoDto
                {
                    EntradaId = x.FaturaId,
                    Id = x.Id,
                    Monto = x.Monto,
                    RowVersion = x.RowVersion,
                    TipoFormaPago = x.TipoFormaPago

                }).OrderBy(x => x.Fecha).ToList();
        }

        public FormaPagoDto ObtenerPorId(long id)
        {
            var formaPago = _formaPagoRepositorio.GetById(id);

            var formaPagoId = new FormaPagoDto
            {
                EntradaId = formaPago.FaturaId,
                Id = formaPago.Id,
                Monto = formaPago.Monto,
                RowVersion = formaPago.RowVersion,
                TipoFormaPago = formaPago.TipoFormaPago
            };

            return formaPagoId;
        }
    }
}
