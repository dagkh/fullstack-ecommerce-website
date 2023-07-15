using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        void Update(User entity);
    }
}
