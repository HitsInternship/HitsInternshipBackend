using MediatR;
using Shared.Extensions.ErrorHandling.Error;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await userRepository.GetByEmailAsync(request.email) != null) throw new ErrorException(409, "Пользователь с таким email уже существует");

            List<Role> roles = await roleRepository.GetRolesAsync(request.roles);

            User user = new User()
            {
                Name = request.name,
                Surname = request.surname,
                Email = request.email,
                Roles = roles
            };

            await userRepository.AddAsync(user);

            return new UserDTO(user);
        }
    }
}
