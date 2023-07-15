using System;
using System.Data.Entity;
using LuigiiLuxury.Domain.Interfaces.Repositories;
    
namespace LuigiiLuxury.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository Brands { get; }
        IAvailabilityStatusRepository AvailabilityStatus { get; }
        ICountriesRepository Countries { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IOrdersRepository Orders { get; }
        IOrderStatusRepository OrderStatus { get; }
        IProductsRepository Products { get; }
        IRolesRepository Roles { get; }
        IUsersRepository Users { get; }

        void Complete();
    }
}