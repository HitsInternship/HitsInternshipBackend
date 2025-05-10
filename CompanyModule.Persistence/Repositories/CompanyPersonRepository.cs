using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using CompanyModule.Infrastructure;
using Shared.Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompanyModule.Persistence.Repositories
{
    public class CompanyPersonRepository : BaseEntityRepository<CompanyPerson>, ICompanyPersonRepository
    {
        private readonly CompanyModuleDbContext _context;

        public CompanyPersonRepository(CompanyModuleDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CompanyPerson>> GetCompanyPersonsByCompany(Company company, bool includeCurators, bool includeRepresenters)
        {
            return _context.CompanyPersons
                .Where(companyPerson => 
                (companyPerson.Company == company) && 
                ((includeCurators && (companyPerson is Curator)) || (includeRepresenters && (companyPerson is CompanyRepresenter)))).ToList();
        }
    }

}
