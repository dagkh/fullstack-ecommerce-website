using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class CountriesRepository : Repository<Country>, ICountriesRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public CountriesRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Update(Country entity)
        {
            var existingEntity = base.Get(entity.Code);

            if (existingEntity != null)
            {
                existingEntity.Name = entity.Name;
                existingEntity.Code = entity.Code;
            }
        }
    }
}
