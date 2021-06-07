using System.Collections.Generic;
using System.Linq;
using PP.Dominio.Repositorio.PlanTarjeta;
using PP.IServicio.PlanTarjeta;

namespace PP.Servicio.PlanTarjeta
{
    public class PlanTarjetaServicio : IPlanTarjetaServicio
    {
        private readonly IPlanTarjetaRepositorio _tarjetaRepositorio;

        public PlanTarjetaServicio(IPlanTarjetaRepositorio tarjetaRepositorio)
        {
            _tarjetaRepositorio = tarjetaRepositorio;
        }


        public void Agregar(PlanTarjetaDto dto)
        {
            var plan = new Dominio.Entidades.PlanTarjeta
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado,
                Interes = dto.Interes,
                TarjetaId = dto.TarjetaId
            };

            _tarjetaRepositorio.Add(plan);
            _tarjetaRepositorio.Save();
        }

        public void Eliminar(long id)
        {
            var plan = _tarjetaRepositorio.GetById(id);

            _tarjetaRepositorio.Delete(plan.Id);
            _tarjetaRepositorio.Save();
        }

        public void Guardar()
        {
            _tarjetaRepositorio.Save();
        }

        public void Modificar(PlanTarjetaDto dto)
        {
            var plan = _tarjetaRepositorio.GetById(dto.Id);

            _tarjetaRepositorio.UpDate(plan);

            plan.Codigo = dto.Codigo;
            plan.Descripcion = dto.Descripcion;
            plan.Eliminado = dto.Eliminado;
            plan.Interes = dto.Interes;
            plan.TarjetaId = dto.TarjetaId;

            _tarjetaRepositorio.Save();
        }

        public IEnumerable<PlanTarjetaDto> Obtener(string cadenaBuscar)
        {
            return _tarjetaRepositorio.GetAll().Where(x => x.Codigo.Contains(cadenaBuscar))
                .Select(x => new PlanTarjetaDto
                {
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Eliminado = x.Eliminado,
                    Id = x.Id,
                    Interes = x.Interes,
                    TarjetaId = x.TarjetaId

                }).OrderBy(x => x.Descripcion).ToList();
        }

        public PlanTarjetaDto ObtenerPorId(long id)
        {
            var plan = _tarjetaRepositorio.GetById(id);

            var planId = new PlanTarjetaDto
            {
                Codigo = plan.Codigo,
                Descripcion = plan.Descripcion,
                Eliminado = plan.Eliminado,
                Id = plan.Id,
                Interes = plan.Interes,
                RowVersion = plan.RowVersion,
                TarjetaId = plan.TarjetaId
            };

            return planId;
        }
    }
}
