using MediatR;
using UserModule.Application;
using UserModule.Contracts.DTOs;
using UserModule.Controllers.CQRS.Queries;
using UserModule.Domain.Entities;

namespace UserModule.Controllers.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDTO>
    {
        private readonly UserService userService;
        public AddUserCommandHandler(UserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            List<Role> roles = await userService.GetRoles(request.UserRequest.roles);

            User user = new User()
            {
                Name = request.UserRequest.name,
                Surname = request.UserRequest.surname,
                Email = request.UserRequest.email,
                Roles = roles
            };

            await userService.AddUser(user);

            return new UserDTO(user);
        }
    }
}
