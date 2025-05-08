using MediatR;
using UserModule.Contracts.DTOs;

namespace UserModule.Contracts.CQRS
{
    public record GetUserInfoQuery(Guid userId) : IRequest<UserDTO> { }
}
