using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Ubicacion;

namespace PP.Servicio.Ubicacion
{
    public class UbicacionServicio: IUbicacionServicio
    {
        private readonly UbicacionRepositorio _ubicacionRepositorio;

        public UbicacionServicio()
            :this(new UbicacionRepositorio())
        {
            
        }

        public UbicacionServicio(UbicacionRepositorio ubicacionRepositorio)
        {
            _ubicacionRepositorio = ubicacionRepositorio;
        }

        public void Agregar(UbicacionDto dto)
        {
            var ubicacion = new Dominio.Entidades.Ubicacion
            {
                Eliminado = dto.Eliminado,
                EventoId = dto.EventoId,
                LocalidadId = dto.LocalidadId,
                NombreEstablecimiento = dto.NombreEstablecimiento,
                PrimDireccion = dto.PrimDireccion,
                SegDireccion = dto.SegDireccion,
            };

            _ubicacionRepositorio.Add(ubicacion);
            _ubicacionRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var ubicacion = _ubicacionRepositorio.GetById(id);

            _ubicacionRepositorio.UpDate(ubicacion);

            ubicacion.Eliminado = !ubicacion.Eliminado;

            _ubicacionRepositorio.Save();
        }

        public void Modificar(UbicacionDto dto)
        {
            var ubicacion = _ubicacionRepositorio.GetById(dto.Id);

            _ubicacionRepositorio.UpDate(ubicacion);

            ubicacion.NombreEstablecimiento = dto.NombreEstablecimiento;
            ubicacion.PrimDireccion = dto.PrimDireccion;
            ubicacion.SegDireccion = dto.SegDireccion;

            _ubicacionRepositorio.Save();
        }

        public IEnumerable<UbicacionDto> Obtener(string cadenaBuscar)
        {
            return _ubicacionRepositorio.GetAll().Select(x => new UbicacionDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Eliminado = x.Eliminado,
                EventoId = x.EventoId,
                LocalidadId = x.LocalidadId,
                NombreEstablecimiento = x.NombreEstablecimiento,
                PrimDireccion = x.PrimDireccion,
                SegDireccion = x.SegDireccion,
            }).ToList();
        }

        public IEnumerable<UbicacionDto> ObtenerPorLocalidad(string cadenaBuscar, long localidadId)
        {
            return _ubicacionRepositorio.GetAll().Where(x => x.Eliminado == false
                                                             && x.LocalidadId == localidadId)
                .Select(x => new UbicacionDto
                {
                    Id = x.Id,
                    RowVersion = x.RowVersion,
                    Eliminado = x.Eliminado,
                    EventoId = x.EventoId,
                    LocalidadId = x.LocalidadId,
                    NombreEstablecimiento = x.NombreEstablecimiento,
                    PrimDireccion = x.PrimDireccion,
                    SegDireccion = x.SegDireccion,
                }).ToList();
        }

        public UbicacionDto ObtenerPorId(long id)
        {
            var ubicacion = _ubicacionRepositorio.GetById(id);

            return new UbicacionDto
            {
                Id = ubicacion.Id,
                RowVersion = ubicacion.RowVersion,
                Eliminado = ubicacion.Eliminado,
                EventoId = ubicacion.EventoId,
                LocalidadId = ubicacion.LocalidadId,
                NombreEstablecimiento = ubicacion.NombreEstablecimiento,
                PrimDireccion = ubicacion.PrimDireccion,
                SegDireccion = ubicacion.SegDireccion,
            };
        }

        public UbicacionDto ObtenerPorEvento(long eventoId)
        {
            var ubi = _ubicacionRepositorio.GetAll().FirstOrDefault(
                x => x.EventoId == eventoId);
            
            return new UbicacionDto
            {
                Id = ubi.Id,
                EventoId = ubi.EventoId,
                RowVersion = ubi.RowVersion,
                LocalidadId = ubi.LocalidadId,
                Eliminado = ubi.Eliminado,
                SegDireccion = ubi.SegDireccion,
                NombreEstablecimiento = ubi.NombreEstablecimiento,
                PrimDireccion = ubi.PrimDireccion
            };
        }
    }
}
