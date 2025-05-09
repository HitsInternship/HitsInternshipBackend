using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Extensions.ErrorHandling.Validation;
using UserModule.Contracts.DTOs;

namespace UserModule.Contracts.Commands;

public record EditUserCommand() : IRequest<UserDto>
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }

    [DataType(DataType.EmailAddress)]
    [Annotations.Email]
    public string email { get; set; }
}