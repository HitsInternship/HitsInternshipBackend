using MediatR;
using UserModule.Contracts.DTOs.Requests;
using UserModule.Contracts.DTOs.Responses;
using UserModule.Domain.Entities;

namespace UserModule.Contracts.CQRS
{
    public record GetUserInfoQuery(Guid userId) : IRequest<User> { }
    public record GetListUserQuery(SearchUserRequest searchRequest) : IRequest<List<User>> { }
}
