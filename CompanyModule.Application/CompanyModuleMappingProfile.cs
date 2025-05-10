using AutoMapper;
using CompanyModule.Contracts.DTOs.Requests;
using CompanyModule.Contracts.DTOs.Responses;
using CompanyModule.Domain.Entities;

namespace CompanyModule.Application;

public class CompanyModuleMappingProfile : Profile
{
    public CompanyModuleMappingProfile()
    {
        CreateMap<CompanyRequest, Company>();
        CreateMap<EditCompanyRequest, Company>();
        CreateMap<Company, CompanyResponse>();

        CreateMap<PartnershipAgreementRequest, PartnershipAgreement>();
        CreateMap<PartnershipAgreement, PartnershipAgreementResponse>();

        CreateMap<CompanyPersonRequest, Curator>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.userRequest));
        CreateMap<CompanyPersonRequest, CompanyRepresenter>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.userRequest));

        CreateMap<CompanyPerson, CompanyPersonResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.surname, opt => opt.MapFrom(src => src.User.Surname))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.User.Email));

        CreateMap<AppointmentRequest, Appointment>();
        CreateMap<Appointment, AppointmentResponse>();
    }
}