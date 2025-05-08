using MediatR;
using Shared.Extensions.ErrorHandling.Validation;
using System.ComponentModel.DataAnnotations;
using UserModule.Contracts.DTOs;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.CQRS
{
    public record CreateUserCommand() : IRequest<UserDTO> 
    {
        public string name { get; set; }
        public string surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Annotations.Email]
        public string email { get; set; }
        public List<RoleName> roles { get; set; }


    }

    public record EditUserCommand() : IRequest<UserDTO> 
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Annotations.Email]
        public string email { get; set; }
    }
}
