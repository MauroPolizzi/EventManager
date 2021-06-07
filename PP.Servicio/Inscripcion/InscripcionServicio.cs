using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Inscripcion;
using PP.IServicio.Inscripcion;

namespace PP.Servicio.Inscripcion
{
    public class InscripcionServicio : IInscripcionServicio
    {
        private readonly IInscripcionRepositorio _inscRepositorio;

        public InscripcionServicio(IInscripcionRepositorio inscRepositorio)
        {
            _inscRepositorio = inscRepositorio;
        }

        public void Agregar(InscripcionDto dto)
        {
            var nuevaInsc = new Dominio.Entidades.Inscripcion
            {
                TiempoInscripcion = dto.TiempoInscripcion,
                ClienteId = 1,
                EventoId = 1,
                Eliminado = dto.Eliminado
            };

            _inscRepositorio.Add(nuevaInsc);
            _inscRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var insc = _inscRepositorio.GetById(id);

            _inscRepositorio.Delete(insc.Id);
            _inscRepositorio.Save();
        }

        public void Guardar()
        {
            _inscRepositorio.Save();
        }

        public void Modificar(InscripcionDto dto)
        {
            var insc = _inscRepositorio.GetById(dto.Id);

            _inscRepositorio.UpDate(insc);

            insc.TiempoInscripcion = dto.TiempoInscripcion;

            _inscRepositorio.Save();
        }

        public IEnumerable<InscripcionDto> Obtener()
        {
            return _inscRepositorio.GetAll()
                .Select(x => new InscripcionDto
                {
                    TiempoInscripcion = x.TiempoInscripcion,
                    Id = x.Id,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public InscripcionDto ObtenerPorId(long id)
        {
            var inscEncontrada = _inscRepositorio.GetById(id);

            var conf = new InscripcionDto
            {
                TiempoInscripcion = inscEncontrada.TiempoInscripcion,
                Id = inscEncontrada.Id,
                RowVersion = inscEncontrada.RowVersion
            };

            return conf;
        }
    }
}
