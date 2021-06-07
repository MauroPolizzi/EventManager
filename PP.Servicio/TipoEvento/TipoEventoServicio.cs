using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.TipoEvento;
using PP.InfraestructuraRepositorio;
using PP.IServicio.TipoEvento;

namespace PP.Servicio.TipoEvento
{
    public class TipoEventoServicio : ITipoEventoServicio
    {
        private readonly TipoEventoRepositorio _tipoEventoRepositorio;

        public TipoEventoServicio()
            :this(new TipoEventoRepositorio())
        {
            
        }

        public TipoEventoServicio(TipoEventoRepositorio tipoEventoRepositorio)
        {
            _tipoEventoRepositorio = tipoEventoRepositorio;
        }

        public void Agregar(TipoEventoDto dto)
        {
            var TEventoNuevo = new Dominio.Entidades.TipoEvento
            {
                Descripcion = dto.Descripcion,
            };

            _tipoEventoRepositorio.Add(TEventoNuevo);
            _tipoEventoRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var tipoEvento = _tipoEventoRepositorio.GetById(id);

            _tipoEventoRepositorio.UpDate(tipoEvento);

            tipoEvento.Eliminado = !tipoEvento.Eliminado;

            _tipoEventoRepositorio.Save();
        }

        public void Guardar()
        {
            _tipoEventoRepositorio.Save();
        }

        public void Modificar(TipoEventoDto dto)
        {
            var tEvento = _tipoEventoRepositorio.GetById(dto.Id);

            _tipoEventoRepositorio.UpDate(tEvento);

            tEvento.Descripcion = dto.Descripcion;

            _tipoEventoRepositorio.Save();
        }

        public IEnumerable<TipoEventoDto> Obtener(string cadenaBuscar)
        {
            return _tipoEventoRepositorio.GetAll().Where(x => x.Descripcion.Contains(cadenaBuscar)
            && x.Eliminado == false)
                .Select(x => new TipoEventoDto
                {
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    RowVersion = x.RowVersion
                }).OrderBy(x=>x.Descripcion).ToList();
        }

        public TipoEventoDto ObtenerPorId(long id)
        {
            var tEventoEncontrado = _tipoEventoRepositorio.GetById(id);

            var tEvento = new TipoEventoDto
            {
                Descripcion = tEventoEncontrado.Descripcion,
                Id = tEventoEncontrado.Id,
                RowVersion = tEventoEncontrado.RowVersion
            };

            return tEvento;
        }
    }
}
