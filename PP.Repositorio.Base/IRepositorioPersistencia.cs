using PP.Dominio.Base;

namespace PP.Repositorio.Base
{
    public  interface IRepositorioPersistencia<T> where T : EntityBase
    {
        void Add(T entity);

        void UpDate(T entity);

        void Delete(long id);

        void Save();
    }
}
