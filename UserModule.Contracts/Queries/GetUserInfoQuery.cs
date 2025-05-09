using MediatR;
using UserModule.Contracts.DTOs;

namespace UserModule.Contracts.Queries;

public record GetUserInfoQuery(Guid UserId) : IRequest<UserDto>;