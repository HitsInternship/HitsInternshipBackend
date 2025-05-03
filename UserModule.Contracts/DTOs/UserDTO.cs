using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.DTOs
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public List<RoleName> roles { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            id = user.Id;
            name = user.Name;
            surname = user.Surname;
            email = user.Email;
            roles = user.Roles.Select(Role => Role.RoleName).ToList();
        }
    }
}
