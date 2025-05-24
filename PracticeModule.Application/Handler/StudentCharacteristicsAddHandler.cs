using MediatR;
using PracticeModule.Contracts.CQRS;
using PracticeModule.Contracts.Model;
using PracticeModule.Infrastructure;

namespace PracticeModule.Application.Handler;

public class StudentCharacteristicsAddHandler : IRequestHandler<StudentCharacteristicsAddQuery>
{
    private readonly PracticeDbContext context;
    
    public StudentCharacteristicsAddHandler(PracticeDbContext context)
    {
        this.context = context;
    }

    public Task Handle(StudentCharacteristicsAddQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}