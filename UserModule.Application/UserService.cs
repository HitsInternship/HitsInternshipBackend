using Shared.Extensions.ErrorHandling.Error;
using UserModule.Contracts.DTOs;
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

        public async Task<User> GetUserById(Guid userId)
        {
            User? user = await userRepository.GetByIdAsync(userId);
            if (user == null) throw new ErrorException(404, "Пользователя с таким id нет");

            await roleRepository.GetRolesByUserId(userId);

            return user;
        }

        public async Task<User?> GetUserNullableByEmail(string email)
        {
            return await userRepository.GetByEmail(email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User? user = await userRepository.GetByEmail(email);
            if (user == null) throw new ErrorException(404, "Пользователя с таким email нет");

            return user;
        }

        public async Task<List<Role>> GetRoles(List<RoleName> roleNames)
        {
            return await roleRepository.GetRoles(roleNames);
        }


        public async Task CreateUser(User user)
        {
            await userRepository.AddAsync(user);
        }

        public async Task EditUser(User user)
        {
            await userRepository.UpdateAsync(user);
        }
    }
}
