using AutoMapper;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Contracts.Queries;
using DeanModule.Contracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Contracts.Configs;

namespace DeanModule.Application.Features.Queries;

public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, ApplicationsDto>
{
    private readonly int _size;
    private readonly IMapper _mapper;
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationsQueryHandler(IApplicationRepository applicationRepository, IOptions<PaginationConfig> config,
        IMapper mapper)
    {
        _size = config.Value.PageSize;
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<ApplicationsDto> Handle(GetApplicationsQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _applicationRepository.CountAsync();

        var skip = (request.Page - 1) * _size;

        var applications = request.IsArchives
            ? await _applicationRepository.ListAllArchivedAsync()
            : await _applicationRepository.ListAllAsync();

        if (request.ApplicationStatus != null)
            applications = applications.Where(x => x.Status == request.ApplicationStatus);

        if (request.StudentId != null)
            applications = applications.Where(x => x.StudentId == request.StudentId);

        var pagedApplications = await applications
            .Skip(skip)
            .Take(_size)
            .ToListAsync(cancellationToken: cancellationToken);

        var dtos = _mapper.Map<List<ListedApplicationResponseDto>>(pagedApplications);

        return new ApplicationsDto(dtos, _size, totalCount, request.Page);
    }
}