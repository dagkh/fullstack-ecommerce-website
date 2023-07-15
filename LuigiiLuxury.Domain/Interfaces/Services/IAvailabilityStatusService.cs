
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Services.IServices;

namespace LuigiiLuxury.Domain.Interfaces.Services
{
    public interface IAvailabilityStatusService : IService<AvailabilityStatusViewModel>
    {
        void Add(AvailabilityStatusFormViewModel availabilityStatusForm);
        void Update(string code, AvailabilityStatusFormViewModel availabilityStatusForm);
    }
}
