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
    public interface ICountriesService : IService<CountryViewModel>
    {
        void Add(CountryFormViewModel countryForm);
        void Update(int id, CountryFormViewModel countryForm);
        IEnumerable<CountryViewModel> GetSorted(string sortedBy);
    }
}
