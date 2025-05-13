using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;

namespace CompanyModule.Application.Handlers
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, Company>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public AddCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(AddCompanyCommand command, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(command.createRequest);

            await _companyRepository.AddAsync(company);

            return company;
        }
    }
}
