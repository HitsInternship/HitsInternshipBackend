using MediatR;
using UserModule.Application;
using UserModule.Contracts.DTOs;
using UserModule.Controllers.CQRS.Queries;

namespace UserModule.Controllers.Handlers
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDTO>
    {
        private readonly UserService userService;

        public GetUserInfoQueryHandler(UserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserDTO> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            return new UserDTO(await userService.GetUser(request.userId));
        }
    }
}
