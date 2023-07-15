using System.Collections.Generic;
using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        void Update(int id, Brand entity);
    }
}
