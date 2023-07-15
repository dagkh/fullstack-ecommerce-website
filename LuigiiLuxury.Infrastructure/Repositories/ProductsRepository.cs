using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public ProductsRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Update(int id, Product product)
        {
            var entity = Get(id);

            entity.Name = product.Name;
            entity.AvailabilityStatusCode = product.AvailabilityStatusCode;
            entity.BrandId = product.BrandId;
            entity.NumberOfProducts = product.NumberOfProducts;
            entity.Price = product.Price;
            entity.DiscountPrice = product.DiscountPrice;
            entity.Description = product.Description;
            entity.Condition = product.Condition;

            if (product.Thumbnail != null)
                entity.Thumbnail = product.Thumbnail;
        }

        public IEnumerable<Product> GetByBrand(int brandId)
        {
            var entities = LuigiiLuxuryContext.Products.Where(p => p.BrandId == brandId).ToList();
            
            return entities;
        }

        public IEnumerable<Product> GetBySearchString(string search)
        {
            var products = LuigiiLuxuryContext.Products.Where(p => p.Name.Contains(search) || p.Brand.Name.Contains(search)).ToList();
            
            return products;
        }

        public void SetAvailibilityStatus(int id, string availabilityStatusCode)
        {
            var entity = Get(id);

            if (entity != null)
                entity.AvailabilityStatusCode = availabilityStatusCode;
        }
    }
}
