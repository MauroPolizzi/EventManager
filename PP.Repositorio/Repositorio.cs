using PP.Dominio.Base;
using PP.Infraestructura.Context;
using PP.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PP.Repositorio
{
    public class Repositorio<T>: IRepositorio<T> where T : EntityBase
    {
        protected DataContext Context;

        public Repositorio()
            :this(new DataContext())
        {
            
        }

        public Repositorio(DataContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(long Id)
        {
            var entity = GetById(Id);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties.Split(','))
            {
                query = query.Include(includeProperty);
            }
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado)
        {
            return Context.Set<T>().AsNoTracking().Where(predicado);
        }
        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties.Split(','))

            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.ToList();
        }
        
        public T GetById(long Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public T GetById(long Id, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var includeProperty in includeProperties.Split(','))

            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(x => x.Id == Id);
        }

        public T GetById(long Id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault(x => x.Id == Id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void UpDate(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
