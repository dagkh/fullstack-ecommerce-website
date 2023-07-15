using System.Collections.Generic;

namespace LuigiiLuxury.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get<T>(T id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
