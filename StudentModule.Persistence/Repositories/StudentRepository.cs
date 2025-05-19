using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using StudentModule.Infrastructure;


namespace StudentModule.Persistence.Repositories
{
    public class StudentRepository : BaseEntityRepository<StudentEntity>, IStudentRepository
    {
        private readonly StudentModuleDbContext context;
        public StudentRepository(StudentModuleDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
