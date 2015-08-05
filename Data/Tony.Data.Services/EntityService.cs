using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Data.Model;
using Tony.Data.Repository;

namespace Tony.Data.Services
{
    public class EntityService<T, TKey> : IEntityService<T, TKey> where T : Entity<TKey>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected IGenericRepository<T, TKey> Repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T, TKey> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }


        public virtual TKey Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Repository.Add(entity);
            UnitOfWork.Commit();
            return entity.Id;
        }


        public virtual TKey Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Repository.Update(entity);
            UnitOfWork.Commit();
            return entity.Id;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Repository.Delete(entity);
            UnitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public int Count()
        {
            return Repository.Count();
        }

    }

    public class EntityService<T> : EntityService<T, int>, IEntityService<T> where T : Entity
    {
        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
            : base(unitOfWork, repository.ToGenericRepositoryOfIntKey())
        {
        }
    }
}
