using MediatR;
using Shared.Extensions.ErrorHandling.Error;
using UserModule.Application;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Domain.Entities;

namespace UserModule.Controllers.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly UserService userService;
        public CreateUserCommandHandler(UserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await userService.GetUserNullableByEmail(request.email) != null) throw new ErrorException(409, "Пользователь с таким email уже существует");

            List<Role> roles = await userService.GetRoles(request.roles);

            User user = new User()
            {
                Name = request.name,
                Surname = request.surname,
                Email = request.email,
                Roles = roles
            };

            await userService.CreateUser(user);

            return new UserDTO(user);
        }
    }
}
