using MediatR;
using Shared.Extensions.ErrorHandling.Error;
using UserModule.Application;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Domain.Entities;

namespace UserModule.Controllers.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, UserDTO>
    {
        private readonly UserService userService;
        public EditUserCommandHandler(UserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserDTO> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            User user = await userService.GetUserById(request.id);

            if (user.Email != request.email && userService.GetUserNullableByEmail(request.email) != null) throw new ErrorException(409, "Пользователь с таким email уже существует");

            user.Name = request.name;
            user.Email = request.email;
            user.Surname = request.surname;

            await userService.EditUser(user);

            return new UserDTO(user);
        }
    }
}
