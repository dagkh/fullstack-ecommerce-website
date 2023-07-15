using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IAvailabilityStatusRepository : IRepository<AvailabilityStatus>
    {
        void Update(string code, AvailabilityStatus entity);
    }
}
