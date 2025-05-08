using Shared.Contracts.Dtos;

namespace DeanModule.Contracts.Dtos.Responses;

public class ApplicationsDto(List<ListedApplicationResponseDto> applications, int size, int count, int current)
{
    public List<ListedApplicationResponseDto> Applications { get; init; } = applications;
    public Pagination Pagination { get; init; } = new(size, count, current);
}