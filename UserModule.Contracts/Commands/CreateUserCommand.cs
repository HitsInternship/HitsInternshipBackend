using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Extensions.ErrorHandling.Validation;
using UserModule.Contracts.DTOs;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.Commands;

public record CreateUserCommand() : IRequest<UserDto>
{
    public string name { get; set; }
    public string surname { get; set; }

    [DataType(DataType.EmailAddress)]
    [Annotations.Email]
    public string email { get; set; }

    public List<RoleName> roles { get; set; }
}