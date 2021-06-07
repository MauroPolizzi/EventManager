using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.FP_Tarjeta;
using PP.IServicio.FP_Tarjeta;

namespace PP.Servicio.FP_Tarjeta
{
    public class FP_TarjetaServicio : IFP_TarjetaServicio
    {
        private readonly IFP_TarjetaRepositorio _tarjetaRepositorio;

        public FP_TarjetaServicio(IFP_TarjetaRepositorio fpTarjetaRepositorio)
        {
            _tarjetaRepositorio = fpTarjetaRepositorio;
        }

        public void Agregar(FP_TarjetaDto dto)
        {
            var tarjeta = new Dominio.Entidades.FP_Tarjeta
            {
                NumeroTarjeta = dto.NumeroTarjeta,
                PlanTarjetaId = dto.PlanTarjetaId
            };

            _tarjetaRepositorio.Add(tarjeta);
            _tarjetaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var tarjeta = _tarjetaRepositorio.GetById(id);

            _tarjetaRepositorio.Delete(tarjeta.Id);
            _tarjetaRepositorio.Save();
        }

        public void Guardar()
        {
            _tarjetaRepositorio.Save();
        }

        public void Modificar(FP_TarjetaDto dto)
        {
            var tarjeta = _tarjetaRepositorio.GetById(dto.Id);

            _tarjetaRepositorio.UpDate(tarjeta);

            tarjeta.NumeroTarjeta = dto.NumeroTarjeta;
            tarjeta.PlanTarjetaId = dto.PlanTarjetaId;

            _tarjetaRepositorio.Save();
        }

        public IEnumerable<FP_TarjetaDto> Obtener(int cadenaBuscar)
        {
            return _tarjetaRepositorio.GetAll().Where(x => x.NumeroTarjeta == cadenaBuscar)
                .Select(x => new FP_TarjetaDto
                {
                    Id = x.Id,
                    NumeroTarjeta = x.NumeroTarjeta,
                    PlanTarjetaId = x.PlanTarjetaId,
                    RowVersion = x.RowVersion

                }).ToList();
        }

        public FP_TarjetaDto ObtenerPorId(long id)
        {
            var tarjeta = _tarjetaRepositorio.GetById(id);

            var tarjetaId = new FP_TarjetaDto
            {
                Id = tarjeta.Id,
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                PlanTarjetaId = tarjeta.PlanTarjetaId,
                RowVersion = tarjeta.RowVersion
            };

            return tarjetaId;
        }
    }
}
