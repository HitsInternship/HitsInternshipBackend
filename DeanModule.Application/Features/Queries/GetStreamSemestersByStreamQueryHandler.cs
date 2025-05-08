using AutoMapper;
using DeanModule.Contracts.Dtos.Responses;
using DeanModule.Contracts.Queries;
using DeanModule.Contracts.Repositories;
using MediatR;

namespace DeanModule.Application.Features.Queries;

public class
    GetStreamSemestersByStreamQueryHandler : IRequestHandler<GetStreamSemestersByStreamQuery,
    List<StreamSemesterResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IStreamSemesterRepository _streamSemesterRepository;

    public GetStreamSemestersByStreamQueryHandler(IMapper mapper, IStreamSemesterRepository streamSemesterRepository)
    {
        _mapper = mapper;
        _streamSemesterRepository = streamSemesterRepository;
    }

    public async Task<List<StreamSemesterResponseDto>> Handle(GetStreamSemestersByStreamQuery request,
        CancellationToken cancellationToken)
    {
        //todo: check stream

        var semesters = (await _streamSemesterRepository.ListAllAsync()).ToList();

        return _mapper.Map<List<StreamSemesterResponseDto>>(semesters);
    }
}