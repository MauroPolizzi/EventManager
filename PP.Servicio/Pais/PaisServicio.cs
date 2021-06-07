using PP.Dominio.Repositorio.Pais;
using PP.IServicio.Pais;
using System.Collections.Generic;
using System.Linq;
using PP.InfraestructuraRepositorio;

namespace PP.Servicio.Pais
{
    public class PaisServicio : IPaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio;

        public PaisServicio()
            :this(new PaisRepositorio())
        {
            
        }

        public PaisServicio(PaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public void Agregar(PaisDto dto)
        {
            var paisNuevo = new Dominio.Entidades.Pais
            {
                Descripcion = dto.Descripcion,
            };

            _paisRepositorio.Add(paisNuevo);
            _paisRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var pais = _paisRepositorio.GetById(id);

            _paisRepositorio.UpDate(pais);

            pais.Eliminado = !pais.Eliminado;

            _paisRepositorio.Save();
        }

        public void Modificar(PaisDto dto)
        {
            var pais = _paisRepositorio.GetById(dto.Id);

            _paisRepositorio.UpDate(pais);

            pais.Descripcion = dto.Descripcion;

            _paisRepositorio.Save();
        }

        public IEnumerable<PaisDto> Obtener(string cadenaBuscar)
        {
            return _paisRepositorio.GetAll().Where(x => x.Descripcion.Contains(cadenaBuscar)
            && x.Eliminado == false)
                .Select(x => new PaisDto
                {
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    RowVersion = x.RowVersion
                }).ToList();
            
        }

        public PaisDto ObtenerPorId(long id)
        {
            var paisEncontrado = _paisRepositorio.GetById(id);

            var pais = new PaisDto
            {
                Descripcion = paisEncontrado.Descripcion,
                Id = paisEncontrado.Id,
                RowVersion = paisEncontrado.RowVersion
            };

            return pais;
        }

        public void Guardar()
        {
            _paisRepositorio.Save();
        }
    }
}
