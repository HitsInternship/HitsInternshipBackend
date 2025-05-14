using AutoMapper;
using CompanyModule.Contracts.Commands;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace CompanyModule.Application.Handlers
{
    public class AddCompanyPersonCommandHandler : IRequestHandler<AddCompanyPersonCommand, CompanyPerson>
    {
        private readonly ICompanyPersonRepository _companyPersonRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public AddCompanyPersonCommandHandler(ICompanyPersonRepository companyPersonRepository, ICompanyRepository companyRepository, IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _companyPersonRepository = companyPersonRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<CompanyPerson> Handle(AddCompanyPersonCommand command, CancellationToken cancellationToken)
        {
            Company company = await _companyRepository.GetByIdAsync(command.companyId);

            CompanyPerson companyPerson = command.createRequest.isCurator ? _mapper.Map<Curator>(command.createRequest) : _mapper.Map<CompanyRepresenter>(command.createRequest);
            companyPerson.Company = company;

            User user;
            if (command.createRequest.userId != null)
            {
                user = await _userRepository.GetByIdAsync((Guid)command.createRequest.userId);
            }
            else
            {
                user = _mapper.Map<User>(command.createRequest.userRequest);
                user.Roles.Add(await _roleRepository.GetRoleAsync(command.createRequest.isCurator ? RoleName.Curator : RoleName.CompanyRepresenter));
                await _userRepository.AddAsync(user);
            }

            companyPerson.UserId = user.Id;
            await _companyPersonRepository.AddAsync(companyPerson);

            return companyPerson;
        }
    }
}
