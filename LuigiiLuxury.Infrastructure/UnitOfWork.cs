using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Repositories;
using LuigiiLuxury.Infrastructure.Repositories;

namespace LuigiiLuxury.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LuigiiLuxuryDbContext _context;

        public IBrandRepository Brands { get; private set; }
        public ICountriesRepository Countries { get; private set; }
        public IProductsRepository Products { get; private set; }
        public IOrderStatusRepository OrderStatus { get; private set; }
        public IRolesRepository Roles { get; private set; }
        public IAvailabilityStatusRepository AvailabilityStatus { get; private set; }
        public IUsersRepository Users { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }

            public UnitOfWork()
        {
            _context = new LuigiiLuxuryDbContext();

            Brands = new BrandsRepository(_context);
            Countries = new CountriesRepository(_context);
            Products = new ProductsRepository(_context);
            OrderStatus = new OrderStatusRepository(_context);
            Roles = new RolesRepository(_context);
            AvailabilityStatus = new AvailabilityStatusRepository(_context);
            Users = new UsersRepository(_context);
            Orders = new OrdersRepository(_context);
            OrderDetails = new OrderDetailsRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
