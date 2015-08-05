using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Data.Model;

namespace Tony.Data.Services
{
    public interface IEntityService<T, TKey> : IService
        where T : Entity<TKey>
    {
        TKey Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        TKey Update(T entity);
        int Count();
    }

    public interface IEntityService<T> : IEntityService<T, int> where T : Entity { }
}
