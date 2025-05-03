using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;
using UserModule.Persistence.Repositories;

namespace UserModule.Application
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<User> GetUser(Guid userId)
        {
            User? user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new User();
            }

            await roleRepository.GetRolesByUserId(userId);

            return user;
        }

        public async Task AddUser(User user)
        {
            await userRepository.AddAsync(user);
        }

        public async Task<List<Role>> GetRoles(List<RoleName> roleNames)
        {
            return await roleRepository.GetRoles(roleNames);
        }
    }
}
