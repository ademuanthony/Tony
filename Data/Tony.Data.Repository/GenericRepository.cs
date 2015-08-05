using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Tony.Data.Model;

namespace Tony.Data.Repository
{

    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
          where T : Entity<TKey>
    {
        protected DbContext Entities;
        protected readonly IDbSet<T> Dbset;

        public GenericRepository(DbContext context)
        {
            //var context = contextFactory.CurrentDbContext;
            Entities = context;
            Dbset = context.Set<T>();
        }

        public T Get(TKey id)
        {
            return Entities.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        { 
            return Entities.Set<T>().SingleOrDefault(match);
        }

        public bool Any(Expression<Func<T, bool>> match)
        {
            return Entities.Set<T>().Any(match);
        }

        public virtual IQueryable<T> GetAll()
        {

            return Dbset.AsQueryable();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            var query = Dbset.Where(predicate).AsQueryable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public TKey AddAndGetId(T entity)
        {
            Dbset.Add(entity);
            Save();
            return entity.Id;
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public TKey UpdateAndGetId(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
            Save();
            return entity.Id;
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null? Dbset.Count(): Dbset.Count(predicate);
        }

        public virtual int Save()
        {
            return Entities.SaveChanges();
        }

        
    }

    public class GenericRepository<T> : GenericRepository<T, int>, IGenericRepository<T>
        where T : Entity
    {
        public GenericRepository(DbContext context)
            : base(context)
        {
            //_contextFactory = contextFactory;
        }

        public GenericRepository<T, int> ToGenericRepositoryOfIntKey()
        {
            return new GenericRepository<T, int>(Entities);
        } 
    }
}
