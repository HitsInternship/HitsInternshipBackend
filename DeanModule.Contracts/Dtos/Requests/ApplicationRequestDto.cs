using Microsoft.AspNetCore.Http;

namespace DeanModule.Contracts.Dtos.Requests;

public class ApplicationRequestDto
{
    public Guid StudentId { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public Guid CompanyId { get; set; }
    public Guid PositionId { get; set; }
    public IFormFile? File { get; set; }
}