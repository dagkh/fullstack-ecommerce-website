using System.Linq;
using System.Collections.Generic;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class AvailabilityStatusRepository : Repository<AvailabilityStatus>, IAvailabilityStatusRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public AvailabilityStatusRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Update(string code, AvailabilityStatus entity)
        {
            var existingEntity = base.Get(code);

            existingEntity.Name = entity.Name;
            existingEntity.Code = entity.Code;
        }
    }
}
