using MediatR;
using Shared.Extensions.ErrorHandling.ErrorException;
using UserModule.Contracts.Commands;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public EditUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.id);
            if (user == null) throw new ErrorException(404, "Пользователя с таким id нет");

            await _roleRepository.GetRolesByUserIdAsync(user.Id);

            if (user.Email != request.email && _userRepository.GetByEmailAsync(request.email) != null)
                throw new ErrorException(409, "Пользователь с таким email уже существует");

            user.Name = request.name;
            user.Email = request.email;
            user.Surname = request.surname;

            await _userRepository.UpdateAsync(user);

            return new UserDto(user);
        }
    }
}