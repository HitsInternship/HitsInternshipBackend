using Shared.Domain.Entites;
using UserModule.Domain.Enums;

namespace UserModule.Domain.Entities
{
    public class Role : BaseEntity
    {
        public RoleName RoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
