using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using UserModule.Domain.Entities;
using UserModule.Infrastructure;
using UserModule.Contracts;
using UserModule.Contracts.Repositories;

namespace UserModule.Persistence.Repositories
{
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        private readonly UserModuleDbContext context;
        public UserRepository(UserModuleDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User?> GetUserWithRoles(Guid id)
        {
            return await context.Users.Include(user => user.Roles).FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
