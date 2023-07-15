using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var entities = _unitOfWork.Products.GetAll().Where(p => p.IsDeleted == false);

            if (entities != null)
            {
                var entites = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(entities);

                return entites.OrderBy(e => e.Id).ToList();
            }
            else
                return null;
        }

        private bool IsExistingInDatabase<T>(T identity)
        {
            var objectFound = Get(identity);

            if (objectFound != null)
                return true;
            return false;
        }

        public ProductViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.Products.Get(id);

            if (entity != null)
            {
                var product = _mapper.Map<Product, ProductViewModel>(entity);

                return product;
            }
            else
                return null;
        }

        public void Add(ProductFormViewModel productForm)
        {
            var entity = new Product
            {
                Name = productForm.Name,
                BrandId = productForm.BrandId,
                NumberOfProducts = productForm.NumberOfProducts,
                Price = productForm.Price,
                DiscountPrice = productForm.DiscountPrice,
                Thumbnail = productForm.Thumbnail,
                Description = productForm.Description,
                Condition = productForm.Condition,
                IsDeleted = false,
                AvailabilityStatusCode = productForm.AvailabilityStatusCode
            };

            _unitOfWork.Products.Add(entity);
            _unitOfWork.Complete();
        }

        public void Delete<T>(T id)
        {
            if (IsExistingInDatabase(id))
            {
                _unitOfWork.Products.Get(id).IsDeleted = true;
                _unitOfWork.Complete();
            }
        }

        public void Update(int id, ProductFormViewModel productForm)
        {
            if (IsExistingInDatabase(id))
            {
                var objectUpdated = _mapper.Map<ProductFormViewModel, Product>(productForm);

                _unitOfWork.Products.Update(id, objectUpdated);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<ProductViewModel> GetByBrand(int brandId)
        {
            var products = GetAll().Where(p => p.BrandId == brandId);

            if (products != null)
                return products;
            else
                return null;
        }

        public IEnumerable<ProductViewModel> GetByAvailibilityStatus(string availabilityStatusCode)
        {
            var products = GetAll().Where(p => p.AvailabilityStatusCode == availabilityStatusCode);

            if (products != null)
                return products;
            else
                return null;
        }

        public void SetAvailibilityStatus(int productId, string availabilityStatusCode)
        {
            if (IsExistingInDatabase(productId))
            {
                var entity = _unitOfWork.Products.Get(productId);
                
                entity.AvailabilityStatusCode = availabilityStatusCode;
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<ProductViewModel> GetBySorted(string sorted)
        {
            var products = GetAll();

            if (sorted == "price-ascending")
            {
                products = products.OrderBy(m => m.Price).ToList();
            }
            else if (sorted == "price-descending")
            {
                products = products.OrderByDescending(m => m.Price).ToList();
            }
            else // availability status code
            {
                products = products.Where(m => m.AvailabilityStatusCode == sorted).ToList();
            }

            return products;
        }
    }
}
