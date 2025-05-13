using MediatR;
using Shared.Domain.Exceptions;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs.Responses;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, User>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<User> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetByIdAsync(request.userId);
            if (user == null) throw new NotFound("No user with such id");

            await roleRepository.GetRolesByUserIdAsync(user.Id);

            return user;
        }
    }
}
