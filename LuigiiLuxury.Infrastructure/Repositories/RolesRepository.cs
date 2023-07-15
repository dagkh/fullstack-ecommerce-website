using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class RolesRepository : Repository<Role>, IRolesRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public RolesRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Update(Role entity)
        {
            var existingEntity = base.Get(entity.Code);

            existingEntity.Name = entity.Name;
            existingEntity.Code = entity.Code;
        }
    }
}
