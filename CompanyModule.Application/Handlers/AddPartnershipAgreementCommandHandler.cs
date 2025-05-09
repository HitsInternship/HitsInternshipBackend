using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using DocumentModule.Contracts.Repositories;
using DocumentModule.Domain.Enums;
using MediatR;

namespace CompanyModule.Application.Handlers
{
    public class AddPartnershipAgreementCommandHandler : IRequestHandler<AddPartnershipAgreementCommand, PartnershipAgreement>
    {
        private readonly IPartnershipAgreementRepository _partnershipAgreementRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public AddPartnershipAgreementCommandHandler(IPartnershipAgreementRepository companyRepository, IFileRepository fileRepository, IMapper mapper)
        {
            _partnershipAgreementRepository = companyRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<PartnershipAgreement> Handle(AddPartnershipAgreementCommand command, CancellationToken cancellationToken)
        {
            PartnershipAgreement agreement = _mapper.Map<PartnershipAgreement>(command.createRequest);

            agreement.DocumentId = Guid.NewGuid();
            await _fileRepository.AddFileAsync(agreement.DocumentId, DocumentType.PartnershipAgreement, command.createRequest.file);

            agreement.Company = await _companyRepository.GetByIdAsync(command.companyId);

            await _partnershipAgreementRepository.AddAsync(agreement);

            return agreement;
        }
    }
}
