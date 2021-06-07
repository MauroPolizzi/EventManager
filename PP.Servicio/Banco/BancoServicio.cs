using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.Banco;
using PP.IServicio.Banco;

namespace PP.Servicio.Banco
{
    public class BancoServicio : IBancoServicio
    {
        private readonly IBancoRepositorio _bancoRepositorio;

        public BancoServicio(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        public void Agregar(BancoDto dto)
        {
            var banco = new Dominio.Entidades.Banco
            {
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado
            };

            _bancoRepositorio.Add(banco);
            _bancoRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var banco = _bancoRepositorio.GetById(id);

            _bancoRepositorio.Delete(banco.Id);
            _bancoRepositorio.Save();
        }

        public void Guardar()
        {
            _bancoRepositorio.Save();
        }

        public void Modificar(BancoDto dto)
        {
            var banco = _bancoRepositorio.GetById(dto.Id);

            _bancoRepositorio.UpDate(banco);

            banco.Descripcion = dto.Descripcion;
            banco.Eliminado = dto.Eliminado;
            
            _bancoRepositorio.Save();
        }

        public IEnumerable<BancoDto> Obtener(string cadenaBuscar)
        {
            return _bancoRepositorio.GetAll().Where(x => x.Descripcion.Contains(cadenaBuscar)
                                                         && x.Eliminado == false)
                .Select(x => new BancoDto
                {
                    Descripcion = x.Descripcion,
                    Eliminado = x.Eliminado,
                    Id = x.Id,
                    RowVersion = x.RowVersion

                }).OrderBy(x => x.Descripcion).ToList();
        }

        public BancoDto ObtenerPorId(long id)
        {
            var banco = _bancoRepositorio.GetById(id);

            var bancoId = new BancoDto
            {
                Descripcion = banco.Descripcion,
                Eliminado = banco.Eliminado,
                Id = banco.Id,
                RowVersion = banco.RowVersion
            };

            return bancoId;
        }
    }
}
