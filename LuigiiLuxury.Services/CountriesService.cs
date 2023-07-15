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
    public class CountriesService : ICountriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CountriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public CountryViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.Countries.Get(id);

            if (entity == null)
                return null;
            else
            {
                var country = _mapper.Map<Country, CountryViewModel>(entity);

                return country;
            }
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            var entities = _unitOfWork.Countries.GetAll();

            if (entities != null)
            {
                var countries = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(entities).OrderBy(c => c.Name);
                return countries;
            }

            return null;
        }

        public IEnumerable<CountryViewModel> GetSorted(string sortedBy)
        {
            var countryForms = this.GetAll();

            if (sortedBy == "countryCode")
            {
                countryForms = countryForms.OrderByDescending(b => b.Code).ToList();
            }
            else if (sortedBy == "countryName")
            {
                countryForms = countryForms.OrderByDescending(b => b.Name).ToList();
            }

            return countryForms;
        }

        public void Delete<T>(T id)
        {
            var countries = Get(id);

            if (countries != null)
            {
                var entity = _unitOfWork.Countries.Get(id);

                _unitOfWork.Countries.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public void Update(int id, CountryFormViewModel countryForm)
        {
            var country = Get(id);

            if (country != null)
            {
                if (countryForm.Code != null && countryForm.Name != null && countryForm.Code != null)
                {
                    var entity = _mapper.Map<CountryFormViewModel, Country>(countryForm);

                    _unitOfWork.Countries.Update(entity);
                }
            }
        }

        public void Add(CountryFormViewModel countryForm)
        {
            if (countryForm.Code != null && countryForm.Name != null && countryForm.Code != null)
            {
                var entity = _mapper.Map<CountryFormViewModel, Country>(countryForm);

                _unitOfWork.Countries.Add(entity);
                _unitOfWork.Complete();
            }
        }
    }
}
