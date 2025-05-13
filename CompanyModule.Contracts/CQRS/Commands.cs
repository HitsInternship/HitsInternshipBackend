using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Domain.Entities;
using CompanyModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CompanyModule.Contracts.CQRS
{
    public record AddCompanyCommand(CompanyRequest createRequest) : IRequest<Company>;
    public record EditCompanyCommand(Guid companyId, EditCompanyRequest editRequest) : IRequest<Company>;
    public record ChangeCompanyStatusCommand(Guid companyId, CompanyStatus companyStatus) : IRequest<Unit>;

    public record AddPartnershipAgreementCommand(Guid companyId, PartnershipAgreementRequest createRequest) : IRequest<PartnershipAgreement>;

    public record AddCompanyPersonCommand(Guid companyId, CompanyPersonRequest createRequest) : IRequest<CompanyPerson>;

    public record AddAppointmentCommand(Guid companyId, AppointmentRequest createRequest) : IRequest<Appointment>;
    public record EditAppointmentCommand(Guid appointmentId, AppointmentRequest editRequest) : IRequest<Appointment>;

    public record AddAttachmentCommand(Guid appointmentId, IFormFile attachment) : IRequest<Guid>;
    public record RemoveAttachmentCommand(Guid attachmentId) : IRequest<Unit>;
}
