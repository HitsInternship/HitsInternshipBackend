using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace CompanyModule.Application.Handlers
{
    public class AddCompanyPersonCommandHandler : IRequestHandler<AddCompanyPersonCommand, CompanyPerson>
    {
        private readonly ICompanyPersonRepository _companyPersonRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddCompanyPersonCommandHandler(ICompanyPersonRepository companyPersonRepository, ICompanyRepository companyRepository, IUserRepository userRepository, IMapper mapper)
        {
            _companyPersonRepository = companyPersonRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CompanyPerson> Handle(AddCompanyPersonCommand command, CancellationToken cancellationToken)
        {
            Company company = await _companyRepository.GetByIdAsync(command.companyId);

            CompanyPerson companyPerson = command.createRequest.isCurator ? _mapper.Map<Curator>(command.createRequest) : _mapper.Map<CompanyRepresenter>(command.createRequest);
            companyPerson.Company = company;

            User user = _mapper.Map<User>(command.createRequest.userRequest); 
            await _userRepository.AddAsync(user);

            companyPerson.UserId = user.Id;
            await _companyPersonRepository.AddAsync(companyPerson);

            return companyPerson;
        }
    }
}
