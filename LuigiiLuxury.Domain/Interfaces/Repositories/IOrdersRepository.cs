using System.Collections.Generic;
using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IOrdersRepository : IRepository<Order>
    {
        void Save(Order entity);
        void Update(int id, Order objectUpdated);

    }
}
