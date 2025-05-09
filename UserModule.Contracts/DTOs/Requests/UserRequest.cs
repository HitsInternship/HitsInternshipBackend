using Shared.Extensions.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.DTOs.Requests
{
    public class UserRequest
    {
        public string name { get; set; }
        public string surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Annotations.Email]
        public string email { get; set; }
        public List<RoleName> roles { get; set; }
    }
}
