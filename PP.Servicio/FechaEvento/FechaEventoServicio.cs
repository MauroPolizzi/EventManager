using System.Collections.Generic;
using System.Linq;
using PP.IServicio.FechaEvento;
using PP.InfraestructuraRepositorio;
using System;

namespace PP.Servicio.FechaEvento
{
    public class FechaEventoServicio: IFechaEventoServicio
    {
        private readonly FechaEventoRepositorio _fechaEventoRepositorio;

        public FechaEventoServicio()
            : this(new FechaEventoRepositorio())
        {

        }

        public FechaEventoServicio(FechaEventoRepositorio fechaEventoRepositorio)
        {
            _fechaEventoRepositorio = fechaEventoRepositorio;
        }

        public void Agregar(FechaEventoDto dto)
        {
            var fecha = new Dominio.Entidades.FechaEvento
            {
                Eliminado = dto.Eliminado,
                EventoId = dto.EventoId,
                FechaDesde = dto.FechaDesde,
                FechaHasta = dto.FechaHasta,
                HoraDesde = dto.HoraDesde,
                HoraHasta = dto.HoraHasta,
                
            };

            _fechaEventoRepositorio.Add(fecha);
            _fechaEventoRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var fecha = _fechaEventoRepositorio.GetById(id);

            _fechaEventoRepositorio.UpDate(fecha);

            fecha.Eliminado = !fecha.Eliminado;

            _fechaEventoRepositorio.Save();
        }

        public void Modificar(FechaEventoDto dto)
        {
            var fecha = _fechaEventoRepositorio.GetById(dto.Id);

            _fechaEventoRepositorio.UpDate(fecha);

            fecha.HoraHasta = dto.HoraHasta;
            fecha.HoraDesde = dto.HoraDesde;
            fecha.FechaHasta = dto.FechaHasta;
            fecha.FechaDesde = dto.FechaDesde;

            _fechaEventoRepositorio.Save();
        }

        public IEnumerable<FechaEventoDto> Obtener(string cadenaBuscar)
        {
            return _fechaEventoRepositorio.GetAll().Select(x => new FechaEventoDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Eliminado = x.Eliminado,
                EventoId = x.EventoId,
                FechaDesde = x.FechaDesde,
                FechaHasta = x.FechaHasta,
                HoraDesde = x.HoraDesde,
                HoraHasta = x.HoraHasta,
                
            }).ToList();
        }

        public IEnumerable<FechaEventoDto> ObtenerPorEvento(string cadenaBuscar, long eventoId)
        {
            return _fechaEventoRepositorio.GetAll().Where(x => x.Eliminado == false
            && x.EventoId == eventoId).Select(x => new FechaEventoDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Eliminado = x.Eliminado,
                EventoId = x.EventoId,
                FechaDesde = x.FechaDesde,
                FechaHasta = x.FechaHasta,
                HoraDesde = x.HoraDesde,
                HoraHasta = x.HoraHasta,

            }).ToList();
        }

        public FechaEventoDto ObtenerPorId(long id)
        {
            var fecha = _fechaEventoRepositorio.GetById(id);

            return new FechaEventoDto
            {
                Id = fecha.Id,
                RowVersion = fecha.RowVersion,
                Eliminado = fecha.Eliminado,
                EventoId = fecha.EventoId,
                FechaDesde = fecha.FechaDesde,
                FechaHasta = fecha.FechaHasta,
                HoraDesde = fecha.HoraDesde,
                HoraHasta = fecha.HoraHasta,
            };
        }

        public FechaEventoDto ObtenerPorEvento(long eventoId)
        {
            var fecha = _fechaEventoRepositorio.GetAll().FirstOrDefault(
                x => x.EventoId == eventoId);

            return new FechaEventoDto
            {
                Id = fecha.Id,
                RowVersion = fecha.RowVersion,
                EventoId = fecha.EventoId,
                FechaDesde = fecha.FechaDesde,
                FechaHasta = fecha.FechaHasta,
                Eliminado = fecha.Eliminado,
                HoraHasta = fecha.HoraHasta,
                HoraDesde = fecha.HoraDesde,
            };
        }
    }
}
