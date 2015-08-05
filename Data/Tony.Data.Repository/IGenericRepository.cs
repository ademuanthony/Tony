using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tony.Data.Model;

namespace Tony.Data.Repository
{
    public interface IGenericRepository<T, TKey> where T : Entity<TKey>
    {
        T Get(TKey id);
        T Find(Expression<Func<T, bool>> match);
        bool Any(Expression<Func<T, bool>> match);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        TKey AddAndGetId(T t);
        T Delete(T entity);
        void Update(T entity);
        TKey UpdateAndGetId(T updated);
        int Count(Expression<Func<T, bool>> predicate = null);
        int Save();
    }

    public interface IGenericRepository<T> : IGenericRepository<T, int> where T : Entity
    {
        GenericRepository<T, int> ToGenericRepositoryOfIntKey();
    }
}
