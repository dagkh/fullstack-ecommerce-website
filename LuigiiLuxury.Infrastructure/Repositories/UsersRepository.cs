using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces.Repositories;

namespace LuigiiLuxury.Infrastructure.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public LuigiiLuxuryDbContext LuigiiLuxuryContext
        {
            get { return Context as LuigiiLuxuryDbContext; }
        }

        public UsersRepository(LuigiiLuxuryDbContext context) : base(context)
        {
        }

        public void Update(User entity)
        {
            var existingEntity = base.Get(entity.Id);

            if (existingEntity != null)
            {
                existingEntity.Id = entity.Id;
                existingEntity.FirstName = entity.FirstName;
                existingEntity.LastName = entity.LastName;
                existingEntity.PhoneNumber = entity.PhoneNumber;
                existingEntity.Address = entity.Address;
                existingEntity.City = entity.City;
            }
        }
    }
}
