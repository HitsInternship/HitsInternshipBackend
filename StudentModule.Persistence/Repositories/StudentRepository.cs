using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using StudentModule.Infrastructure;


namespace StudentModule.Persistence.Repositories
{
    public class StudentRepository(StudentModuleDbContext context)
        : BaseEntityRepository<StudentEntity>(context), IStudentRepository
    {
        public async Task<List<StudentEntity>> GetStudentsByGroup(int groupNumber)
        {
            return await DbSet.Where(x => x.Group.GroupNumber == groupNumber).AsNoTracking().ToListAsync();
        }
    }
}