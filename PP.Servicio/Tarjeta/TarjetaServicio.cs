using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Tarjeta;
using PP.IServicio.Tarjeta;

namespace PP.Servicio.Tarjeta
{
    public class TarjetaServicio : ITarjetaServicio
    {
        private readonly ITarjetaRepositorio _tarjetaRepositorio;

        public TarjetaServicio(ITarjetaRepositorio tarjetaRepositorio)
        {
            _tarjetaRepositorio = tarjetaRepositorio;
        }


        public void Agregar(TarjetaDto dto)
        {
            var tarjeta = new Dominio.Entidades.Tarjeta
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado,
            };

            _tarjetaRepositorio.Add(tarjeta);
            _tarjetaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var tarjeta = _tarjetaRepositorio.GetById(id);
            
            _tarjetaRepositorio.UpDate(tarjeta);

            tarjeta.Eliminado = !tarjeta.Eliminado;

            _tarjetaRepositorio.Save();
        }

        public void Guardar()
        {
            _tarjetaRepositorio.Save();
        }

        public void Modificar(TarjetaDto dto)
        {
            var tarjeta = _tarjetaRepositorio.GetById(dto.Id);

            _tarjetaRepositorio.UpDate(tarjeta);

            tarjeta.Codigo = dto.Codigo;
            tarjeta.Descripcion = dto.Descripcion;
            tarjeta.Eliminado = dto.Eliminado;

            _tarjetaRepositorio.Save();
        }

        public IEnumerable<TarjetaDto> Obtener(string cadenaBuscar)
        {
            return _tarjetaRepositorio.GetAll().Where(x => x.Codigo.Contains(cadenaBuscar))
                .Select(x => new TarjetaDto
                {
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Eliminado = x.Eliminado,
                    Id = x.Id,
                    RowVersion = x.RowVersion

                }).OrderBy(x => x.Descripcion).ToList();
        }

        public TarjetaDto ObtenerPorId(long id)
        {
            var tarjeta = _tarjetaRepositorio.GetById(id);

            var tarjetaId = new TarjetaDto
            {
                Codigo = tarjeta.Codigo,
                Descripcion = tarjeta.Descripcion,
                Eliminado = tarjeta.Eliminado,
                Id = tarjeta.Id,
                RowVersion = tarjeta.RowVersion
            };

            return tarjetaId;
        }
    }
}
