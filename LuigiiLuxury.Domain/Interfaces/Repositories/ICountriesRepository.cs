using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface ICountriesRepository : IRepository<Country>
    {
        void Update(Country entity);
    }
}
