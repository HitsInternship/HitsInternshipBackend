using DocumentModule.Contracts.Queries;
using DocumentModule.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PracticeModule.Contracts.CQRS;
using PracticeModule.Domain.Entity;
using PracticeModule.Infrastructure;
using Shared.Domain.Exceptions;

namespace PracticeModule.Application.Handler;

public class PracticeDiaryAddHandler :  IRequestHandler<PracticeDiaryAddQuery>
{
    
    private readonly PracticeDbContext context;
    private readonly IMediator mediator;
    public PracticeDiaryAddHandler(PracticeDbContext context, IMediator mediator)
    {
        this.context = context;
        this.mediator = mediator;
    }
    
    public async Task Handle(PracticeDiaryAddQuery request, CancellationToken cancellationToken)
    {
        var getPractice = await context.Practice.FirstOrDefaultAsync(x => x.Id == request.IdPractice, cancellationToken);
        if (getPractice == null)
        {
            throw new NotFound("Practice does not exist");
        }
        var command = new LoadDocumentCommand(DocumentType.PracticeDiary, request.FormPhoto);
        var id = await mediator.Send(command, cancellationToken);

        context.PracticeDiary.Add(new PracticeDiary()
        {
            
            Id = Guid.NewGuid(),
            DocumentId = id,
            PracticeId = request.IdPractice
        });
        
        await context.SaveChangesAsync();
    }
}