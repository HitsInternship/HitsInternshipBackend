using MediatR;
using Shared.Extensions.ErrorHandling.Error;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, UserDTO>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        public EditUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<UserDTO> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetByIdAsync(request.id);
            if (user == null) throw new ErrorException(404, "Пользователя с таким id нет");

            await roleRepository.GetRolesByUserIdAsync(user.Id);

            if (user.Email != request.email && userRepository.GetByEmailAsync(request.email) != null) throw new ErrorException(409, "Пользователь с таким email уже существует");

            user.Name = request.name;
            user.Email = request.email;
            user.Surname = request.surname;

            await userRepository.UpdateAsync(user);

            return new UserDTO(user);
        }
    }
}
