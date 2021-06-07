using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Configuracion;
using PP.IServicio.Configuracion;

namespace PP.Servicio.Configuracion
{
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        private readonly IConfiguracionRepositorio _confRepositorio;

        public ConfiguracionServicio(IConfiguracionRepositorio confRepositorio)
        {
            _confRepositorio = confRepositorio;
        }
        public void Agregar(ConfiguracionDto dto)
        {
            var nuevaConf = new Dominio.Entidades.Configuracion
            {
                Publica = dto.Publica,
                MostrarCantidadEntradas = dto.MostrarCantidadEntradas
            };

            _confRepositorio.Add(nuevaConf);
            _confRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var conf = _confRepositorio.GetById(id);

            _confRepositorio.Delete(conf.Id);
            _confRepositorio.Save();
        }

        public void Guardar()
        {
            _confRepositorio.Save();
        }

        public void Modificar(ConfiguracionDto dto)
        {
            var conf = _confRepositorio.GetById(dto.Id);

            _confRepositorio.UpDate(conf);

            conf.Publica = dto.Publica;
            conf.MostrarCantidadEntradas = dto.MostrarCantidadEntradas;

            _confRepositorio.Save();
        }

        public IEnumerable<ConfiguracionDto> Obtener()
        {
            return _confRepositorio.GetAll()
                .Select(x => new ConfiguracionDto
                {
                    Publica = x.Publica,
                    MostrarCantidadEntradas = x.MostrarCantidadEntradas,
                    Id = x.Id,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public ConfiguracionDto ObtenerPorId(long id)
        {
            var confEncontrada = _confRepositorio.GetById(id);

            var conf = new ConfiguracionDto
            {
                Publica = confEncontrada.Publica,
                MostrarCantidadEntradas = confEncontrada.MostrarCantidadEntradas,
                Id = confEncontrada.Id,
                RowVersion = confEncontrada.RowVersion
            };

            return conf;
        }
    }
}
