using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PP.Dominio.Base;

namespace PP.Repositorio.Base
{
    public  interface IRepositorioConsulta<T> where T : EntityBase
    {
        T GetById(long Id);
        T GetById(long Id, string includeProperties);
        T GetById(long Id, params Expression<Func<T,object>>[] includeProperties);

        //=========================================

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string includeProperties);
        IEnumerable<T> GetAll(params Expression<Func<T,object>>[] includeProperties);

        //=========================================

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, string includeProperties);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, Expression<Func<T,object>>[] includeProperties);
    }
}
