using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using CompanyModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace CompanyModule.Persistence.Repositories
{
    public class CompanyRepository : BaseEntityRepository<Company>, ICompanyRepository
    {
        private readonly CompanyModuleDbContext context;

        public CompanyRepository(CompanyModuleDbContext context) : base(context)
        {
            this.context = context;
        }
    }

}
