using AutoMapper;
using DeanModule.Application.Exceptions;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Contracts.Queries;
using DeanModule.Contracts.Repositories;
using MediatR;
using Shared.Domain.Exceptions;

namespace DeanModule.Application.Features.Queries;

public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, ApplicationResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationQueryHandler(IMapper mapper, IApplicationRepository applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<ApplicationResponseDto> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
    {
        if (!await _applicationRepository.CheckIfExistsAsync(request.ApplicationId))
            throw new ApplicationNotFound(request.ApplicationId);

        var application = await _applicationRepository.GetByIdAsync(request.ApplicationId);

        if (application.StudentId != request.UserId) // todo: add role check
            throw new Forbidden("You are not allowed to access this page");

        if (application.IsDeleted) // todo: add role check
            throw new BadRequest("The application is deleted");

        return _mapper.Map<ApplicationResponseDto>(application);
    }
}