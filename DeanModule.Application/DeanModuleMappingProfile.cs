using AutoMapper;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Domain.Entities;

namespace DeanModule.Application;

public class DeanModuleMappingProfile : Profile
{
    DeanModuleMappingProfile()
    {
        CreateMap<SemesterRequestDto, SemesterEntity>();
        CreateMap<SemesterEntity, SemesterResponseDto>();
    }
}