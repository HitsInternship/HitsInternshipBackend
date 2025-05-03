using MediatR;
using UserModule.Contracts.DTOs;
using UserModule.Domain.Entities;

namespace UserModule.Controllers.CQRS.Queries
{
    public record AddUserCommand(UserDTO UserRequest) : IRequest<UserDTO> { }
}
