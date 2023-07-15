using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public OrdersRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public IList<Order> GetOrdersByUserId(int userId)
        {
            var orders = LuigiiLuxuryContext.Orders.Where(o => o.UserId == userId).ToList();
            return orders;
        }

        public void Save(Order order)
        {
            if (order.Id == 0)
            {
                order.OrderStatusCode = "processing";
                LuigiiLuxuryContext.Orders.Add(order);
            }
            else
            {
                var entity = LuigiiLuxuryContext.Orders.SingleOrDefault(o => o.Id == order.Id);

                if (entity != null)
                {
                    entity.Email = order.Email;
                    entity.ShipFullName = order.ShipFullName;
                    entity.ShipPhoneNumber = order.ShipPhoneNumber;
                    entity.ShipAddress = order.ShipAddress;
                    entity.ShipCity = order.ShipCity;
                    entity.ShipRegion = order.ShipRegion;
                    entity.Note = order.Note;
                    entity.CountryCode = order.CountryCode;
                    entity.OrderStatusCode = "processing";
                }
            }

            LuigiiLuxuryContext.SaveChanges();
        }

        public void Update(int id, Order objectUpdated) 
        {
            var entity = Get(id);

            entity.ShipFullName = objectUpdated.ShipFullName;
            entity.ShipPhoneNumber = objectUpdated.ShipPhoneNumber;
            entity.ShipAddress = objectUpdated.ShipAddress;
            entity.ShipCity = objectUpdated.ShipCity;
            entity.Note = objectUpdated.Note;
            entity.ShipRegion = objectUpdated.ShipRegion;
            entity.CountryCode = objectUpdated.CountryCode;
            entity.OrderStatusCode = objectUpdated.OrderStatusCode;
        }
    }
}
