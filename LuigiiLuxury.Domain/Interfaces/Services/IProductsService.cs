using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Services.IServices;

namespace LuigiiLuxury.Domain.Interfaces.Services
{
    public interface IProductsService : IService<ProductViewModel>
    {
        void Add(ProductFormViewModel productForm);
        void Update(int id, ProductFormViewModel productForm);
        IEnumerable<ProductViewModel> GetByBrand(int brandId);
        IEnumerable<ProductViewModel> GetByAvailibilityStatus(string availibilityStatusCode);
        IEnumerable<ProductViewModel> GetBySorted(string sorted);
        void SetAvailibilityStatus(int productId, string availibilityStatusCode);
    }
}
