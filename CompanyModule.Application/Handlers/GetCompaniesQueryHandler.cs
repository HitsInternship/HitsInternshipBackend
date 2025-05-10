using AutoMapper;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;
using static CompanyModule.Contracts.CQRS.Queries;

namespace CompanyModule.Application.Handlers
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<Company>>
    {
        private readonly ICompanyRepository _companyRepository;
        public GetCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> Handle(GetCompaniesQuery query, CancellationToken cancellationToken)
        {
            return (await _companyRepository.GetAllAsync())!.ToList();
        }
    }
}
