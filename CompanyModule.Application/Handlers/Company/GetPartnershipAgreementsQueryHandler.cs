using AutoMapper;
using CompanyModule.Contracts.CQRS;
using CompanyModule.Contracts.Repositories;
using CompanyModule.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Application.Handlers
{
    public class GetPartnershipAgreementsQueryHandler : IRequestHandler<GetPartnershipAgreementsQuery, List<PartnershipAgreement>>
    {
        private readonly IPartnershipAgreementRepository _partnershipAgreementRepository;
        public GetPartnershipAgreementsQueryHandler(IPartnershipAgreementRepository partnershipAgreementRepository)
        {
            _partnershipAgreementRepository = partnershipAgreementRepository;
        }

        public async Task<List<PartnershipAgreement>> Handle(GetPartnershipAgreementsQuery query, CancellationToken cancellationToken)
        {
            return (await _partnershipAgreementRepository.ListAllAsync()).Where(agreement => agreement.Company.Id == query.companyId).ToList();
        }
    }
}
