using AutoMapper;
using CompanyModule.Contracts.Commands;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;

namespace CompanyModule.Application.Handlers
{
    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, Company>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public EditCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            Company company = await _companyRepository.GetByIdAsync(command.companyId);
            _mapper.Map(command.editRequest, company);

            await _companyRepository.UpdateAsync(company);

            return company;
        }
    }
}
