using DeanModule.Application.Exceptions;
using DeanModule.Contracts.Commands.Semester;
using DeanModule.Contracts.Commands.StreamSemester;
using DeanModule.Contracts.Dtos.Requests;
using DeanModule.Contracts.Repositories;
using DeanModule.Domain.Entities;
using MediatR;

namespace DeanModule.Application.Features.Commands.StreamSemester;

public class UpdateStreamSemesterCommandHandler : IRequestHandler<UpdateStreamSemester, Unit>
{
    private readonly ISemesterRepository _semesterRepository;
    private readonly IStreamSemesterRepository _streamSemesterRepository;

    public UpdateStreamSemesterCommandHandler(ISemesterRepository semesterRepository,
        IStreamSemesterRepository streamSemesterRepository)
    {
        _semesterRepository = semesterRepository;
        _streamSemesterRepository = streamSemesterRepository;
    }


    public async Task<Unit> Handle(UpdateStreamSemester request, CancellationToken cancellationToken)
    {
        if (!await _streamSemesterRepository.CheckIfExistsAsync(request.StreamSemesterId))
            throw new StreamSemesterNotFound(request.StreamSemesterId);

        //todo: check stream
        
        if (!await _semesterRepository.CheckIfExistsAsync(request.StreamSemesterRequestDto.SemesterId))
            throw new SemesterNotFound(request.StreamSemesterRequestDto.StreamId);

        var streamSemester = await _streamSemesterRepository.GetByIdAsync(request.StreamSemesterId);

        await UpdateEntityAsync(streamSemester, request.StreamSemesterRequestDto);

        await _streamSemesterRepository.UpdateAsync(streamSemester);

        return Unit.Value;
    }

    private async Task UpdateEntityAsync(StreamSemesterEntity entity, StreamSemesterRequestDto dto)
    {
        entity.StreamId = dto.StreamId;
        entity.SemesterId = dto.SemesterId;
        entity.Number = dto.Number;
        entity.SemesterEntity = await _semesterRepository.GetByIdAsync(dto.SemesterId);
    }
}