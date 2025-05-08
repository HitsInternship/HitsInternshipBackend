using AutoMapper;
using DeanModule.Application.Exceptions;
using DeanModule.Contracts.Commands.StreamSemester;
using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using MediatR;

namespace DeanModule.Application.Features.Commands.StreamSemester;

public class CreateStreamSemesterCommandHandler : IRequestHandler<CreateStreamSemesterCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ISemesterRepository _semesterRepository;
    private readonly IStreamSemesterRepository _streamSemesterRepository;

    public CreateStreamSemesterCommandHandler(IMapper mapper, IStreamSemesterRepository streamSemesterRepository,
        ISemesterRepository semesterRepository)
    {
        _mapper = mapper;
        _streamSemesterRepository = streamSemesterRepository;
        _semesterRepository = semesterRepository;
    }

    public async Task<Unit> Handle(CreateStreamSemesterCommand request, CancellationToken cancellationToken)
    {
        //todo: check stream

        if (!await _semesterRepository.CheckIfExistsAsync(request.SemesterRequestDto.SemesterId))
            throw new SemesterNotFound(request.SemesterRequestDto.SemesterId);

        var streamSemester = _mapper.Map<StreamSemesterEntity>(request.SemesterRequestDto);

        streamSemester.SemesterEntity = await _semesterRepository.GetByIdAsync(streamSemester.SemesterId);

        await _streamSemesterRepository.AddAsync(streamSemester);

        return Unit.Value;
    }
}