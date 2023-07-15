using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using LuigiiLuxury.Domain.Interfaces;

namespace LuigiiLuxury.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get<T>(T id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
    }
}
