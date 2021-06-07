using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Localidad;

namespace PP.Servicio.Localidad
{
    public class LocalidadServicio: ILocalidadServicio
    {
        private readonly LocalidadRepositorio _localidadRepositorio;

        public LocalidadServicio()
            : this(new LocalidadRepositorio())
        {

        }

        public LocalidadServicio(LocalidadRepositorio localidadRepositorio)
        {
            _localidadRepositorio = localidadRepositorio;
        }

        public void Agregar(LocalidadDto dto)
        {
            var localidad = new Dominio.Entidades.Localidad
            {
                CodigoPostal = dto.CodigoPostal,
                Descripcion = dto.Descripcion,
                Eliminado = false,
                ProvinciaId = dto.ProvinciaId,
            };

            _localidadRepositorio.Add(localidad);
            _localidadRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var localidad = _localidadRepositorio.GetById(id);

            _localidadRepositorio.UpDate(localidad);

            localidad.Eliminado = !localidad.Eliminado;

            _localidadRepositorio.Save();
        }

        public void Modificar(LocalidadDto dto)
        {
            var localidad = _localidadRepositorio.GetById(dto.Id);

            _localidadRepositorio.UpDate(localidad);

            localidad.Descripcion = dto.Descripcion;
            localidad.CodigoPostal = dto.CodigoPostal;

            _localidadRepositorio.Save();
        }

        public IEnumerable<LocalidadDto> Obtener(string cadenaBuscar)
        {
            return _localidadRepositorio.GetAll().Where(x => x.Eliminado == false).Select(x => new LocalidadDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Eliminado = x.Eliminado,
                Descripcion = x.Descripcion,
                CodigoPostal = x.CodigoPostal,
                ProvinciaId = x.ProvinciaId,
            }).OrderBy(x => x.Descripcion).ToList();
        }

        public LocalidadDto ObtenerPorId(long id)
        {
            var localidad = _localidadRepositorio.GetById(id);

            return new LocalidadDto
            {
                Id = localidad.Id,
                RowVersion = localidad.RowVersion,
                Eliminado = localidad.Eliminado,
                Descripcion = localidad.Descripcion,
                CodigoPostal = localidad.CodigoPostal,
                ProvinciaId = localidad.ProvinciaId,
            };
        }
    }
}
