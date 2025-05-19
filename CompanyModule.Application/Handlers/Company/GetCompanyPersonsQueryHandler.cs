using CompanyModule.Contracts.Queries;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace CompanyModule.Application.Handlers.Company
{
    public class GetCompanyPersonsQueryHandler : IRequestHandler<GetCompanyPersonsQuery, List<CompanyPerson>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyPersonRepository _companyPersonRepository;
        public GetCompanyPersonsQueryHandler(ICompanyRepository companyRepository, IUserRepository userRepository, ICompanyPersonRepository companyPersonRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _companyPersonRepository = companyPersonRepository;
        }

        public async Task<List<CompanyPerson>> Handle(GetCompanyPersonsQuery query, CancellationToken cancellationToken)
        {
            Domain.Entities.Company company = await _companyRepository.GetByIdAsync(query.companyId);
            List<CompanyPerson> companyPersons = await _companyPersonRepository.GetCompanyPersonsByCompany(company, query.includeCurators, query.includeRepresenters);

            List<Guid> userIds = companyPersons.Select(companyPerson => companyPerson.UserId).ToList();
            List<User> users = (await _userRepository.ListAllAsync()).Where(user => userIds.Contains(user.Id)).ToList();

            foreach (CompanyPerson companyPerson in companyPersons)
            {
                companyPerson.User = users.First(user => user.Id == companyPerson.UserId);
            }
            
            return companyPersons;
        }
    }
}
