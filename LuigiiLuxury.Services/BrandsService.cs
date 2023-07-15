using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class BrandsService : IBrandsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public BrandsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public BrandViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.Brands.Get(id);

            if (entity == null)
                return null;
            else
            {
                var brand = _mapper.Map<Brand, BrandViewModel>(entity);

                return brand;
            }
        }
        private bool IsExistingInDatabase<T>(T identity)
        {
            var objectFound = Get(identity);

            if (objectFound != null)
                return true;
            return false;
        }

        public IEnumerable<BrandViewModel> GetAll()
        {
            var entities = _unitOfWork.Brands.GetAll();

            if (entities != null)
            {
                var brands = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(entities).OrderBy(b => b.Id);

                return brands;
            }
            else
                return null;
        }

        public string GetName(int id)
        {
            if (IsExistingInDatabase(id))
                return Get(id).Name;
            else
                return null;
        }

        public void Delete<T>(T id)
        {
            if (IsExistingInDatabase(id))
            {
                var entity = _unitOfWork.Brands.Get(id);

                _unitOfWork.Brands.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public void Add(BrandFormViewModel brandForm)
        {
            if (brandForm.Id > 0 && brandForm.Name != null)
            {
                var entity = _mapper.Map<BrandFormViewModel, Brand>(brandForm);

                _unitOfWork.Brands.Add(entity);
                _unitOfWork.Complete();
            }
        }

        public void Update(int id, BrandFormViewModel brandForm)
        {
            if (IsExistingInDatabase(id))
            {
                if (brandForm.Id > 0 && brandForm.Name != null)
                {
                    var entity = _mapper.Map<BrandFormViewModel, Brand>(brandForm);

                    _unitOfWork.Brands.Update(id, entity);
                    _unitOfWork.Complete();
                }
            }
        }
    }
}
