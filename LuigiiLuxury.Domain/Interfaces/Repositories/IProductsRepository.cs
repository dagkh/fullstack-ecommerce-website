using System.Collections.Generic;
using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        void Update(int id, Product product);
        IEnumerable<Product> GetByBrand(int brandId);
        void SetAvailibilityStatus(int productId, string availabilityStatusCode);
    }
}
