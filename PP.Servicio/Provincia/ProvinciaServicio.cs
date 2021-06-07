using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Provincia;
using PP.InfraestructuraRepositorio;
using PP.IServicio.Provincia;

namespace PP.Servicio.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly ProvinciaRepositorio _iProvinciaRepositorio;

        public ProvinciaServicio()
            :this(new ProvinciaRepositorio())
        {
            
        }
        public ProvinciaServicio(ProvinciaRepositorio iProvinciaRepositorio)
        {
            _iProvinciaRepositorio = iProvinciaRepositorio;
        }

        public void Agregar(ProvinciaDto dto)
        {
            var provincia = new Dominio.Entidades.Provincia
            {
                Descripcion = dto.Descripcion,
                Eliminado = false,
                PaisId = dto.PaisId,
            };
            _iProvinciaRepositorio.Add(provincia);
            _iProvinciaRepositorio.Save();
        }

        public void Modificar(ProvinciaDto dto)
        {
            var provincia = _iProvinciaRepositorio.GetById(dto.Id);

            _iProvinciaRepositorio.UpDate(provincia);

            provincia.Descripcion = dto.Descripcion;
            _iProvinciaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var provincia = _iProvinciaRepositorio.GetById(id);

            _iProvinciaRepositorio.UpDate(provincia);

            provincia.Eliminado = !provincia.Eliminado;

            _iProvinciaRepositorio.Save();
        }

        public IEnumerable<ProvinciaDto> ObtenerPorPais(long id)
        {
            var prov = _iProvinciaRepositorio.GetAll().Where(
                x => x.PaisId == id).Select(x => new ProvinciaDto
            {
                Descripcion = x.Descripcion,
                Eliminado = x.Eliminado,
                Id = x.Id,
                //PaisDescripcion = x.Pais.Descripcion,
                //PaisId = x.PaisId,
                RowVersion = x.RowVersion
                }).ToList();

            return prov;
        }

        public IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar)
        {
            return _iProvinciaRepositorio.GetByFilter(
                x => x.Descripcion.Contains(cadenaBuscar)
                     && x.Eliminado == false, "Pais").Select(x => new ProvinciaDto
            {
                Descripcion = x.Descripcion,
                Eliminado = x.Eliminado,
                Id = x.Id,
                PaisDescripcion = x.Pais.Descripcion,
                PaisId = x.PaisId,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public ProvinciaDto ObtenerPorId(long id)
        {
            var prov = _iProvinciaRepositorio.GetById(id);

            return new ProvinciaDto
            {
                Descripcion = prov.Descripcion,
                Eliminado = prov.Eliminado,
                Id = prov.Id,
                //PaisDescripcion = prov.Pais.Descripcion,
                PaisId = prov.PaisId,
                RowVersion = prov.RowVersion
            };


        }

        public void Guardar()
        {
            _iProvinciaRepositorio.Save();
        }
    }
}
