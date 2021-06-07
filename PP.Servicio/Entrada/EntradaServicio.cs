using System;
using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Entrada;

namespace PP.Servicio.Entrada
{
    public class EntradaServicio : IEntradaServicio
    {
        private readonly EntradaRepositorio _entradaRepositorio;

        public EntradaServicio()
            : this(new EntradaRepositorio())
        {

        }

        public EntradaServicio(EntradaRepositorio entradaRepositorio)
        {
            _entradaRepositorio = entradaRepositorio;
        }

        public void Agregar(EntradaDto dto)
        {
            var entrada = new Dominio.Entidades.Entrada
            {
                CantidadDisponible = dto.CantidadDisponible,
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado,
                EventoId = dto.EvetnoId,
                MaximoPermitido = dto.MaximoPermitido,
                MinimoPermitido = dto.MinimoPermitido,
                Precio = dto.Precio,
                TipoEntrada = dto.TipoEntrada,
                NombreEntrada = dto.NombreEntrada
            };

            _entradaRepositorio.Add(entrada);
            _entradaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var entrada = _entradaRepositorio.GetById(id);

            _entradaRepositorio.UpDate(entrada);

            entrada.Eliminado = !entrada.Eliminado;

            _entradaRepositorio.Save();
        }

        public void Modificar(EntradaDto dto)
        {
            var entrada = _entradaRepositorio.GetById(dto.Id);

            _entradaRepositorio.UpDate(entrada);

            entrada.CantidadDisponible = dto.CantidadDisponible;
            entrada.Descripcion = dto.Descripcion;
            entrada.MaximoPermitido = dto.MaximoPermitido;
            entrada.MinimoPermitido = dto.MinimoPermitido;
            entrada.Precio = dto.Precio;
            entrada.TipoEntrada = dto.TipoEntrada;
            entrada.NombreEntrada = dto.NombreEntrada;

            _entradaRepositorio.Save();
        }

        public IEnumerable<EntradaDto> Obtener(string cadenaBuscar)
        {
            return _entradaRepositorio.GetAll().Select(x => new EntradaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                CantidadDisponible = x.CantidadDisponible,
                Descripcion = x.Descripcion,
                Eliminado = x.Eliminado,
                EvetnoId = x.EventoId,
                MaximoPermitido = x.MaximoPermitido,
                MinimoPermitido = x.MinimoPermitido,
                Precio = x.Precio,
                TipoEntrada = x.TipoEntrada,
                NombreEntrada = x.NombreEntrada
            }).ToList();
        }
        public IEnumerable<EntradaDto> ObtenerPorEvento(string cadenaBuscar, long eventoId)
        {
            return _entradaRepositorio.GetAll().Where(x => x.Eliminado == false
            && x.EventoId == eventoId).Select(x => new EntradaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                CantidadDisponible = x.CantidadDisponible,
                Descripcion = x.Descripcion,
                Eliminado = x.Eliminado,
                EvetnoId = x.EventoId,
                MaximoPermitido = x.MaximoPermitido,
                MinimoPermitido = x.MinimoPermitido,
                Precio = x.Precio,
                TipoEntrada = x.TipoEntrada,
                NombreEntrada = x.NombreEntrada
            }).ToList();
        }
        public EntradaDto ObtenerPorId(long id)
        {
            var entrada = _entradaRepositorio.GetById(id);

            return new EntradaDto
            {
                Id = entrada.Id,
                RowVersion = entrada.RowVersion,
                CantidadDisponible = entrada.CantidadDisponible,
                Descripcion = entrada.Descripcion,
                Eliminado = entrada.Eliminado,
                EvetnoId = entrada.EventoId,
                MaximoPermitido = entrada.MaximoPermitido,
                MinimoPermitido = entrada.MinimoPermitido,
                Precio = entrada.Precio,
                TipoEntrada = entrada.TipoEntrada,
                NombreEntrada = entrada.NombreEntrada
            };
        }

        public EntradaDto ObtenerPorEvento(long eventoId)
        {
            var entrada = _entradaRepositorio.GetAll().FirstOrDefault(
                z => z.EventoId == eventoId);

            return new EntradaDto
            {
                CantidadDisponible = entrada.CantidadDisponible,
                Descripcion = entrada.Descripcion,
                EvetnoId = entrada.EventoId,
                Eliminado = entrada.Eliminado,
                Id = entrada.Id,
                MinimoPermitido = entrada.MinimoPermitido,
                MaximoPermitido = entrada.MaximoPermitido,
                NombreEntrada = entrada.NombreEntrada,
                Precio = entrada.Precio,
                TipoEntrada = entrada.TipoEntrada,
                RowVersion = entrada.RowVersion
            };
        }
    }
}
