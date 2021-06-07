using PP.Dominio.Base;

namespace PP.Repositorio.Base
{
    public interface IRepositorio<T> : IRepositorioPersistencia<T> , IRepositorioConsulta<T> where T : EntityBase
    {

    }
}
