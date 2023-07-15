using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class BrandsRepository : Repository<Brand>, IBrandRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public BrandsRepository(LuigiiLuxuryDbContext context) : base(context)
        {

        }

        public void Update(int id, Brand entity)
        {
            var existingEntity = base.Get(id);

            existingEntity.Name = entity.Name;
        }
    }
}
