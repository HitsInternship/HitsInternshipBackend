using Shared.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace UserModule.Contracts.Repositories
{
    public interface IRoleRepository : IBaseEntityRepository<Role>
    {
        public Task<List<Role>> GetRoles(List<RoleName> roleNames);

        public Task<List<Role>> GetRolesByUserId(Guid userId);
    }
}
