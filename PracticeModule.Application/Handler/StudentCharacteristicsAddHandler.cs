using DocumentModule.Contracts.Queries;
using DocumentModule.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PracticeModule.Contracts.CQRS;
using PracticeModule.Contracts.Model;
using PracticeModule.Domain.Entity;
using PracticeModule.Infrastructure;
using Shared.Domain.Exceptions;

namespace PracticeModule.Application.Handler;

public class StudentCharacteristicsAddHandler : IRequestHandler<StudentCharacteristicsAddQuery>
{
    private readonly PracticeDbContext context;
    private readonly IMediator mediator;
    public StudentCharacteristicsAddHandler(PracticeDbContext context, IMediator mediator)
    {
        this.context = context;
        this.mediator = mediator;
    }

    public async Task Handle(StudentCharacteristicsAddQuery request, CancellationToken cancellationToken)
    {
        var getPractice = await context.Practice.FirstOrDefaultAsync(x => x.Id == request.IdPractice, cancellationToken);
        if (getPractice == null)
        {
            throw new NotFound("Practice does not exist");
        }
        var command = new LoadDocumentCommand(DocumentType.StudentPracticeCharacteristic, request.FormPhoto);
        var id = await mediator.Send(command, cancellationToken);

        context.StudentPracticeCharacteristic.Add(new StudentPracticeCharacteristic()
        {
            
            Id = Guid.NewGuid(),
            DocumentId = id,
            PracticeId = request.IdPractice
        });
        
        await context.SaveChangesAsync();
    }
}