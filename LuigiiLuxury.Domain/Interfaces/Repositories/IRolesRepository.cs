using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Domain.Interfaces.Repositories
{
    public interface IRolesRepository : IRepository<Role>
    {
        void Update(Role entity);
    }
}
