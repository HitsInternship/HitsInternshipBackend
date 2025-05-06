using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using CompanyModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace CompanyModule.Persistence.Repositories
{
    public class CompanyPersonRepository : BaseEntityRepository<CompanyPerson>, ICompanyPersonRepository
    {
        private readonly CompanyModuleDbContext context;

        public CompanyPersonRepository(CompanyModuleDbContext context) : base(context)
        {
            this.context = context;
        }
    }

}
