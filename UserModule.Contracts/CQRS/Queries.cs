using MediatR;
using UserModule.Contracts.DTOs.Responses;
using UserModule.Domain.Entities;

namespace UserModule.Contracts.CQRS
{
    public record GetUserQuery(Guid userId) : IRequest<User> { }
}
