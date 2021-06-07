using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.PreguntaFrecuente;
using PP.IServicio.PreguntaFrecuente;

namespace PP.Servicio.PreguntaFrecuente
{
    public class PreguntaFrecuenteServicio : IPreguntaFrecuenteServicio
    {
        private readonly IPreguntaFrecuenteRepositorio _pFrecuenteRepositorio;

        public PreguntaFrecuenteServicio(IPreguntaFrecuenteRepositorio pFrecuenteRepositorio)
        {
            _pFrecuenteRepositorio = pFrecuenteRepositorio;
        }
        public void Agregar(PreguntaFrecuenteDto dto)
        {
            var pFrecNuevo = new Dominio.Entidades.PreguntaFrecuente
            {
                Descripcion = dto.Descripcion,
                Respuesta = dto.Respuesta,
                EventoId = dto.EventoId
            };

            _pFrecuenteRepositorio.Add(pFrecNuevo);
            _pFrecuenteRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            //var pFrec = _pFrecuenteRepositorio.GetById(id);

            //_pFrecuenteRepositorio.Delete(pFrec.Id);
            //_pFrecuenteRepositorio.Save();

            var pregunta = _pFrecuenteRepositorio.GetById(id);

            _pFrecuenteRepositorio.UpDate(pregunta);

            pregunta.Eliminado = !pregunta.Eliminado;

            _pFrecuenteRepositorio.Save();
        }

        public void Guardar()
        {
            _pFrecuenteRepositorio.Save();
        }

        public void Modificar(PreguntaFrecuenteDto dto)
        {
            var pFrec = _pFrecuenteRepositorio.GetById(dto.Id);

            _pFrecuenteRepositorio.UpDate(pFrec);

            pFrec.Descripcion = dto.Descripcion;
            pFrec.Respuesta = dto.Respuesta;


            _pFrecuenteRepositorio.Save();
        }

        public IEnumerable<PreguntaFrecuenteDto> Obtener(string cadenaBuscar)
        {
            return _pFrecuenteRepositorio.GetAll().Where(x => x.Descripcion.Contains(cadenaBuscar)
            && x.Eliminado == false)
                .Select(x => new PreguntaFrecuenteDto
                {
                    Descripcion = x.Descripcion,
                    Respuesta = x.Respuesta,
                    EventoId = x.EventoId,
                    Id = x.Id,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public PreguntaFrecuenteDto ObtenerPorId(long id)
        {
            var pFreEncontrado = _pFrecuenteRepositorio.GetById(id);

            var pfrec = new PreguntaFrecuenteDto
            {
                Descripcion = pFreEncontrado.Descripcion,
                Respuesta = pFreEncontrado.Respuesta,
                Id = pFreEncontrado.Id,
                RowVersion = pFreEncontrado.RowVersion
            };

            return pfrec;
        }
    }
}
