using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;
using UserModule.Infrastructure;

namespace UserModule.Persistence.Repositories
{
    public class RoleRepository : BaseEntityRepository<Role>, IRoleRepository
    {
        private readonly UserModuleDbContext context;
        public RoleRepository(UserModuleDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Role>> GetRolesAsync(List<RoleName> roleNames)
        {
            return context.Roles.Where(Role => roleNames.Contains(Role.RoleName)).ToList();
        }

        public async Task<List<Role>?> GetRolesByUserIdAsync(Guid userId)
        {
            return context.Users.Where(user => user.Id == userId).Include(user => user.Roles).FirstOrDefault()?.Roles;
        }
    }
}
