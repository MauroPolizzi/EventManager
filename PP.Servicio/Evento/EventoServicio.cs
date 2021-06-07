using System;
using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Evento;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Evento;

namespace PP.Servicio.Evento
{
    public class EventoServicio : IEventoServicio
    {
        private readonly EventoRepositorio _eventoRepositorio;
        private readonly FechaEventoRepositorio _fechaEventoRepositorio;
        private readonly UbicacionRepositorio _ubicacionRepositorio;
        private readonly LocalidadRepositorio _localidadRepositorio;
        private readonly ProvinciaRepositorio _provinciaRepositorio;
        private readonly EntradaRepositorio _entradaRepositorio;

        public EventoServicio()
            :this(new EventoRepositorio(), new FechaEventoRepositorio()
                 ,new UbicacionRepositorio(), new LocalidadRepositorio()
                 ,new ProvinciaRepositorio(), new EntradaRepositorio())
        {
            
        }
        public EventoServicio(EventoRepositorio eventoRepositorio,
            FechaEventoRepositorio fechaEventoRepositorio,
            UbicacionRepositorio ubicacionRepositorio,
            LocalidadRepositorio localidadRepositorio,
            ProvinciaRepositorio provinciaRepositorio,
            EntradaRepositorio entradaRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
            _fechaEventoRepositorio = fechaEventoRepositorio;
            _ubicacionRepositorio = ubicacionRepositorio;
            _localidadRepositorio = localidadRepositorio;
            _provinciaRepositorio = provinciaRepositorio;
            _entradaRepositorio = entradaRepositorio;
        }
        

        public void Agregar(EventoDetailDto dto)
        {
            var nuevoEvento = new Dominio.Entidades.Evento
            {
                Nombre = dto.Nombre,
                Imagen = dto.Imagen,
                
                Descripcion = dto.Descripcion,
                Email = dto.Email,
                NombreOrganizador = dto.NombreOrganizador,
                ApellidoOrganizador = dto.ApellidoOrganizador,
                InformacionAdicional = dto.InformacionAdicional,
                Facebook = dto.Facebook,
                Twitter = dto.Twitter,
                Eliminado = false,
                TipoEventoId = dto.TipoEventoId
            };

            _eventoRepositorio.Add(nuevoEvento);
            _eventoRepositorio.Save();

            var fecha = new Dominio.Entidades.FechaEvento
            {
                Eliminado = false,
                EventoId = nuevoEvento.Id,
                FechaDesde = dto.FechaDesde,
                FechaHasta = dto.FechaHasta,
                HoraDesde = dto.HoraDesde,
                HoraHasta = dto.HoraHasta,

            };

            _fechaEventoRepositorio.Add(fecha);

            var entrada = new Dominio.Entidades.Entrada
            {
                CantidadDisponible = dto.CantidadDisponible,
                Descripcion = dto.DescripcionEntrada,
                Eliminado = false,
                EventoId = nuevoEvento.Id,
                MaximoPermitido = dto.MaximoPermitido,
                MinimoPermitido = dto.MinimoPermitido,
                Precio = dto.Precio,
                TipoEntrada = dto.TipoEntrada,
                NombreEntrada = dto.NombreEntrada
            };

            _entradaRepositorio.Add(entrada);

            var ubicacion = new Dominio.Entidades.Ubicacion
            {
                Eliminado = dto.Eliminado,
                EventoId = nuevoEvento.Id,
                LocalidadId = dto.LocalidadId,
                NombreEstablecimiento = dto.NombreEstablecimiento,
                PrimDireccion = dto.PrimDireccion,
                SegDireccion = dto.SegDireccion,
            };

            _ubicacionRepositorio.Add(ubicacion);

            _fechaEventoRepositorio.Save();
            _ubicacionRepositorio.Save();
            _entradaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var evento = _eventoRepositorio.GetById(id);

            _eventoRepositorio.UpDate(evento);

            evento.Eliminado = !evento.Eliminado;

            _eventoRepositorio.Save();
        }

        public void Guardar()
        {
            _eventoRepositorio.Save();
        }

        public void Modificar(EventoDto dto)
        {
            var evento = _eventoRepositorio.GetById(dto.Id);

            _eventoRepositorio.UpDate(evento);

            
            evento.Nombre = dto.Nombre;
            evento.Imagen = dto.Imagen;
            evento.Descripcion = dto.Descripcion;
            evento.Email = dto.Email;
            evento.NombreOrganizador = dto.NombreOrganizador;
            evento.ApellidoOrganizador = dto.ApellidoOrganizador;
            evento.InformacionAdicional = dto.InformacionAdicional;
            evento.Facebook = dto.Facebook;
            evento.Twitter = dto.Twitter;

            _eventoRepositorio.Save();
        }

        public IEnumerable<EventoDto> Obtener(string cadenaBuscar)
        {
            return _eventoRepositorio.GetAll().Where(x => x.Descripcion.Contains(cadenaBuscar))
                .Select(x => new EventoDto
                {
                    Nombre = x.Nombre,
                    Imagen = x.Imagen,
                    Descripcion = x.Descripcion,
                    Email = x.Email,
                    NombreOrganizador = x.NombreOrganizador,
                    ApellidoOrganizador = x.ApellidoOrganizador,
                    InformacionAdicional = x.InformacionAdicional,
                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    Id = x.Id,
                    TipoEventoId = x.TipoEventoId,
                    RowVersion = x.RowVersion
                }).OrderBy(x=>x.Nombre).ToList();
        }

        public IEnumerable<EventoDto> ObtenerPorTipo(long id)
        {
            List<EventoDto> listEventos = new List<EventoDto>();

            var eventos = _eventoRepositorio.GetAll().Where(x => x.Eliminado == false
                                                                 && x.TipoEventoId == id);
            foreach (var evento in eventos)
            {
                var fecha = _fechaEventoRepositorio.GetAll().FirstOrDefault(x => x.EventoId == evento.Id);
                var ubicacion = _ubicacionRepositorio.GetAll().FirstOrDefault(x => x.EventoId == evento.Id);

                var even = new EventoDto
                {
                    ApellidoOrganizador = evento.ApellidoOrganizador,
                    Descripcion = evento.Descripcion,
                    Eliminado = evento.Eliminado,
                    Email = evento.Email,
                    Facebook = evento.Facebook,
                    Imagen = evento.Imagen,
                    InformacionAdicional = evento.InformacionAdicional,
                    Nombre = evento.Nombre,
                    NombreOrganizador = evento.NombreOrganizador,
                    TipoEventoId = evento.TipoEventoId,
                    RowVersion = evento.RowVersion,
                    Id = evento.Id,
                    Twitter = evento.Twitter,

                    FechaDesde = fecha.FechaDesde,
                    HoraDesde = fecha.HoraDesde,

                    UbicacionEstablecimiento = ubicacion.NombreEstablecimiento,
                    UbicacionPrimDireccion = ubicacion.PrimDireccion,
                };

                listEventos.Add(even);
            }

            return listEventos;
        }

        public EventoDto ObtenerPorId(long id)
        {
            var eventoEncontrado = _eventoRepositorio.GetById(id);

            var evento = new EventoDto
            {
                Nombre = eventoEncontrado.Nombre,
                Imagen = eventoEncontrado.Imagen,
                Descripcion = eventoEncontrado.Descripcion,
                Email = eventoEncontrado.Email,
                NombreOrganizador = eventoEncontrado.NombreOrganizador,
                ApellidoOrganizador = eventoEncontrado.ApellidoOrganizador,
                InformacionAdicional = eventoEncontrado.InformacionAdicional,
                Facebook = eventoEncontrado.Facebook,
                Twitter = eventoEncontrado.Twitter,
                Id = eventoEncontrado.Id,
                RowVersion = eventoEncontrado.RowVersion,
                TipoEventoId = eventoEncontrado.TipoEventoId
            };

            return evento;
        }

        public IEnumerable<EventoDto> ObtenerCercanos(DateTime fechaActual)
        {
            List<EventoDto> listEvetos = new List<EventoDto>();

            var eventos = _eventoRepositorio.GetAll()
                .Where(x => x.Eliminado == false);

            foreach (var evento in eventos.ToList())
            {
                var fecha = _fechaEventoRepositorio.GetAll()
                    .Where(x => x.EventoId == evento.Id && x.FechaDesde >= fechaActual);

                foreach (var fec in fecha)
                {
                    var ubicacion = _ubicacionRepositorio.GetAll()
                        .Where(x => x.EventoId == fec.EventoId);

                    foreach (var ubi in ubicacion)
                    {
                        var localidad = _localidadRepositorio.GetById(ubi.LocalidadId);
                        var provincia = _provinciaRepositorio.GetById(localidad.ProvinciaId);

                        if (provincia.Descripcion == "Tucuman")
                        {
                            var even = new EventoDto
                            {
                                Nombre = evento.Nombre,
                                Imagen = evento.Imagen,
                                Descripcion = evento.Descripcion,
                                Email = evento.Email,
                                NombreOrganizador = evento.NombreOrganizador,
                                ApellidoOrganizador = evento.ApellidoOrganizador,
                                InformacionAdicional = evento.InformacionAdicional,
                                Facebook = evento.Facebook,
                                Twitter = evento.Twitter,
                                TipoEventoId = evento.TipoEventoId,
                                Id = evento.Id,
                                RowVersion = evento.RowVersion,

                                FechaDesde = fec.FechaDesde,
                                HoraDesde = fec.HoraDesde
                            };

                            listEvetos.Add(even);
                        }
                    }
                }

            }
            return listEvetos;
        }
    }
}
