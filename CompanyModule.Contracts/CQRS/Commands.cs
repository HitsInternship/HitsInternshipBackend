using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Domain.Entities;
using CompanyModule.Domain.Enums;
using MediatR;

namespace CompanyModule.Contracts.CQRS
{
    public record AddCompanyCommand(CompanyRequest createRequest) : IRequest<Company>;

    public record EditCompanyCommand(Guid companyId, EditCompanyRequest editRequest) : IRequest<Company>;

    public record ChangeCompanyStatusCommand(Guid companyId, CompanyStatus companyStatus) : IRequest<Unit>;

    public record AddPartnershipAgreementCommand(Guid companyId, PartnershipAgreementRequest createRequest) : IRequest<PartnershipAgreement>;

    public record AddCompanyPersonCommand(Guid companyId, CompanyPersonRequest createRequest) : IRequest<CompanyPerson>;

    public record AddAppointmentCommand(Guid companyId, AppointmentRequest createRequest) : IRequest<Appointment>;
}
