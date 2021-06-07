using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.FP_Transferencia;
using PP.IServicio.FP_Transferencia;

namespace PP.Servicio.FP_Transferencia
{
    public class FP_TransferenciaServicio : IFP_TransferenciaServicio
    {
        private readonly IFP_TransferenciaRepositorio _transferenciaRepositorio;

        public FP_TransferenciaServicio(IFP_TransferenciaRepositorio transferenciaRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
        }

        public void Agregar(FP_TransferenciaDto dto)
        {
            var transferencia = new Dominio.Entidades.FP_Transferencia
            {
                NumeroCuenta = dto.NumeroCuenta,
                NumeroCuentaReceptora = dto.NumeroCuentaReceptora,
                Propietario = dto.Propietario,
                BancoId = dto.BancoId
            };

            _transferenciaRepositorio.Add(transferencia);
            _transferenciaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var transferencia = _transferenciaRepositorio.GetById(id);

            _transferenciaRepositorio.Delete(transferencia.Id);
        }

        public void Guardar()
        {
            _transferenciaRepositorio.Save();
        }

        public void Modificar(FP_TransferenciaDto dto)
        {
            var transferencia = _transferenciaRepositorio.GetById(dto.Id);

            _transferenciaRepositorio.UpDate(transferencia);

            transferencia.NumeroCuenta = dto.NumeroCuenta;
            transferencia.NumeroCuentaReceptora = dto.NumeroCuentaReceptora;
            transferencia.Propietario = dto.Propietario;
            transferencia.BancoId = dto.BancoId;

            _transferenciaRepositorio.Save();
        }

        public IEnumerable<FP_TransferenciaDto> Obtener(int cadenaBuscar)
        {
            return _transferenciaRepositorio.GetAll().Where(x => x.NumeroCuenta == cadenaBuscar)
                .Select(x => new FP_TransferenciaDto
                {
                    BancoId = x.BancoId,
                    Id = x.Id,
                    NumeroCuenta = x.NumeroCuenta,
                    NumeroCuentaReceptora = x.NumeroCuentaReceptora,
                    Propietario = x.Propietario

                }).ToList();
        }

        public FP_TransferenciaDto ObtenerPorId(long id)
        {
            var transferencia = _transferenciaRepositorio.GetById(id);

            var transferenciaId = new FP_TransferenciaDto
            {
                BancoId = transferencia.BancoId,
                Id = transferencia.Id,
                NumeroCuenta = transferencia.NumeroCuenta,
                NumeroCuentaReceptora = transferencia.NumeroCuentaReceptora,
                Propietario = transferencia.Propietario,
                RowVersion = transferencia.RowVersion
            };

            return transferenciaId;
        }
    }
}
