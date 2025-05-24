using DocumentModule.Domain.Enums;
using MediatR;

namespace DocumentModule.Contracts.Queries
{
    public record RemoveDocumentCommand(Guid documentId, DocumentType documentType) : IRequest<Unit>;
}
