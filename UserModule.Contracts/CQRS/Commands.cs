using MediatR;
using Shared.Extensions.Validation;
using System.ComponentModel.DataAnnotations;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.DTOs.Requests;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.CQRS
{
    public record CreateUserCommand(UserRequest createRequest) : IRequest<User>;

    public record EditUserCommand(Guid userId, UserRequest editRequest) : IRequest<User>;
}
