using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace DocumentModule.Contracts
{
    public interface IFileRepository
    {
        Task<string> AddFileAsync(Guid fileId, IFormFile file);
        Task<FileContentResult> GetFileAsync(Guid fileId);
        Task DeleteFileAsync(Guid fileId);
    }
}
