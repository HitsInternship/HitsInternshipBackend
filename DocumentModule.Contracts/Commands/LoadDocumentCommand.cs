using DocumentModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DocumentModule.Contracts.Queries
{
    public record LoadDocumentCommand(DocumentType documentType, IFormFile file) : IRequest<Guid>;
}
