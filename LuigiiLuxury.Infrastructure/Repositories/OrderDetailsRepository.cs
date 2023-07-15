using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public OrderDetailsRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }
    }
}
