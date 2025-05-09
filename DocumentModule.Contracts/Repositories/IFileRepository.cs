using DocumentModule.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace DocumentModule.Contracts.Repositories
{
    public interface IFileRepository
    {
        Task<string> AddFileAsync(Guid fileId, DocumentType documentType, IFormFile file);
        Task<FileContentResult> GetFileAsync(Guid fileId, DocumentType documentType);
        Task DeleteFileAsync(Guid fileId, DocumentType documentType);
    }
}
