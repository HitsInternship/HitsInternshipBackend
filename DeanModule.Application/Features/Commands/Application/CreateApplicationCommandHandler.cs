using AutoMapper;
using DeanModule.Contracts.Commands.Application;
using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using MediatR;

namespace DeanModule.Application.Features.Commands.Application;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IApplicationRepository _applicationRepository;

    public CreateApplicationCommandHandler(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        //todo: check student, company and position

        var application = _mapper.Map<ApplicationEntity>(request.ApplicationRequestDto);

        //todo: add document

        await _applicationRepository.AddAsync(application);

        return Unit.Value;
    }
}