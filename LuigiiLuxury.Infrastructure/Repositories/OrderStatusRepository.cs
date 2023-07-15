using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public OrderStatusRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Save(OrderStatus orderStatus)
        {
            if (orderStatus.Code == null)
                LuigiiLuxuryContext.OrderStatus.Add(orderStatus);
            else
            {
                var entity = Get(orderStatus.Code);

                if (entity != null)
                {
                    entity.Code = orderStatus.Code;
                    entity.Name = orderStatus.Name;
                }
            }

            LuigiiLuxuryContext.SaveChanges();
        }

        public void Update(OrderStatus orderStatus)
        {
            var entity = this.Get(orderStatus.Code);

            entity.Name = orderStatus.Name;
            entity.Code = orderStatus.Code;
        }
    }
}
