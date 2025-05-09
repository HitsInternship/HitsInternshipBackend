using MediatR;
using Shared.Extensions.ErrorHandling.ErrorException;
using UserModule.Contracts.Commands;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByEmailAsync(request.email) != null)
                throw new ErrorException(409, "Пользователь с таким email уже существует");

            List<Role> roles = await _roleRepository.GetRolesAsync(request.roles);

            User user = new User()
            {
                Name = request.name,
                Surname = request.surname,
                Email = request.email,
                Roles = roles
            };

            await _userRepository.AddAsync(user);

            return new UserDto(user);
        }
    }
}