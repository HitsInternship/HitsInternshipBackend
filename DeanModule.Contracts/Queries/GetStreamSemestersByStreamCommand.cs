using DeanModule.Contracts.Dtos.Responses;
using MediatR;

namespace DeanModule.Contracts.Queries;

public record GetStreamSemestersByStreamCommand(Guid StreamId) : IRequest<List<StreamSemesterResponseDto>>;