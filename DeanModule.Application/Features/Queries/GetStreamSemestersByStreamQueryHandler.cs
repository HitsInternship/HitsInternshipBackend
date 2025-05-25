using AutoMapper;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Contracts.Queries;
using DeanModule.Contracts.Repositories;
using MediatR;
using Shared.Domain.Exceptions;
using StudentModule.Contracts.Repositories;

namespace DeanModule.Application.Features.Queries;

public class
    GetStreamSemestersByStreamQueryHandler : IRequestHandler<GetStreamSemestersByStreamQuery,
    List<StreamSemesterResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IStreamSemesterRepository _streamSemesterRepository;
    private readonly IStreamRepository _streamRepository;

    public GetStreamSemestersByStreamQueryHandler(IMapper mapper, IStreamSemesterRepository streamSemesterRepository,
        IStreamRepository streamRepository)
    {
        _mapper = mapper;
        _streamSemesterRepository = streamSemesterRepository;
        _streamRepository = streamRepository;
    }

    public async Task<List<StreamSemesterResponseDto>> Handle(GetStreamSemestersByStreamQuery request,
        CancellationToken cancellationToken)
    {
        if (!await _streamRepository.CheckIfExistsAsync(request.StreamId))
            throw new NotFound("Stream does not exist");

        var semesters = (await _streamSemesterRepository.ListAllAsync()).ToList();

        return _mapper.Map<List<StreamSemesterResponseDto>>(semesters);
    }
}