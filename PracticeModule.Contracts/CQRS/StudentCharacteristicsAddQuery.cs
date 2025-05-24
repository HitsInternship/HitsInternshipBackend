using MediatR;
using Microsoft.AspNetCore.Http;

namespace PracticeModule.Contracts.Model;

public class StudentCharacteristicsAddQuery : IRequest
{ 
    public Guid IdPractice { get; set; }
    public IFormFile? FormPhoto { get; set; }
}