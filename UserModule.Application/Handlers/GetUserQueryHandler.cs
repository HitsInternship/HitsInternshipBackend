using MediatR;
using Shared.Extensions.ErrorHandling.ErrorException;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Queries;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) throw new ErrorException(404, "Пользователя с таким id нет");

            await _roleRepository.GetRolesByUserIdAsync(user.Id);

            return new UserDto(user);
        }
    }
}