using DocumentModule.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentModule.Contracts.CQRS
{
    public record GetDocumentNameQuery(Guid documentId, DocumentType documentType) : IRequest<string>;
    public record GetDocumentQuery(Guid documentId, DocumentType documentType) : IRequest<FileContentResult>;
}
