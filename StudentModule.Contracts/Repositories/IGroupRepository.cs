using Shared.Contracts.Repositories;
using StudentModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Contracts.Repositories
{
    public interface IGroupRepository : IBaseEntityRepository<GroupEntity>
    {
        Task<List<GroupEntity>> GetGroupAsync();
    }
}
