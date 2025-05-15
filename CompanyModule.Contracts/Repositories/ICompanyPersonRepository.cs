using CompanyModule.Domain.Entities;
using Shared.Contracts.Repositories;

namespace CompanyModule.Contracts.Repositories
{
    public interface ICompanyPersonRepository : IBaseEntityRepository<CompanyPerson>
    {
        public Task<List<CompanyPerson>> GetCompanyPersonsByCompany(Company company, bool includeCurators, bool includeRepresenters);
    }
}
