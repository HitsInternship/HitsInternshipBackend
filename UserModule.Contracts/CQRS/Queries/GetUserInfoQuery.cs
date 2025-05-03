using MediatR;
using UserModule.Contracts.DTOs;

namespace UserModule.Controllers.CQRS.Queries
{
    public record GetUserInfoQuery(Guid userId) : IRequest<UserDTO> { }
}
