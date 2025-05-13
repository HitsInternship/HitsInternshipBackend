using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using StudentModule.Infrastructure;

namespace StudentModule.Persistence.Repositories
{
    public class GroupRepository : BaseEntityRepository<GroupEntity>, IGroupRepository
    {
        private readonly StudentModuleDbContext context;
        public GroupRepository(StudentModuleDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<GroupEntity>> GetGroupAsync()
        {
            var groups = context.Groups.Include(g => g.Students).ToList();

            return groups;
        }
    }
}
