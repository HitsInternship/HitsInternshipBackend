using MediatR;
using Shared.Extensions.ErrorHandling.Error;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDTO>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<UserDTO> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetByIdAsync(request.userId);
            if (user == null) throw new ErrorException(404, "Пользователя с таким id нет");

            await roleRepository.GetRolesByUserIdAsync(user.Id);

            return new UserDTO(user);
        }
    }
}
