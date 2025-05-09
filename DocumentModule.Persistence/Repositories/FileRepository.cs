using DocumentModule.Contracts.Repositories;
using DocumentModule.Domain.Enums;
using DocumentModule.Infrastructure.FileStorage;
using Microsoft.AspNetCore.Http;
using Minio.DataModel.Args;
using System.Web.Mvc;

namespace DocumentModule.Persistence.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileStorageContext _context;

        public FileRepository(FileStorageContext context)
        {
            _context = context;
        }

        public async Task<string> AddFileAsync(Guid fileId, DocumentType documentType, IFormFile file)
        {
            var args = new PutObjectArgs()
                .WithBucket(documentType.ToString())
                .WithObject(fileId.ToString())
                .WithStreamData(file.OpenReadStream())
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType)
                .WithHeaders(new Dictionary<string, string> { { "Name", Uri.EscapeDataString(file.FileName) } });

            await _context._client.PutObjectAsync(args);
            return file.ContentType;
        }

        public async Task<FileContentResult?> GetFileAsync(Guid fileId, DocumentType documentType)
        {
            using var memoryStream = new MemoryStream();

            var metadata = await _context._client.GetObjectAsync(
                new GetObjectArgs()
                    .WithBucket(documentType.ToString())
                    .WithObject(fileId.ToString())
                    .WithCallbackStream(stream => stream.CopyTo(memoryStream)));

            if (metadata == null) return null;

            return new FileContentResult(memoryStream.ToArray(), metadata.ContentType)
            {
                FileDownloadName = Uri.UnescapeDataString(metadata.MetaData["Name"])
            };
        }

        public async Task DeleteFileAsync(Guid fileId, DocumentType documentType)
        {
            await _context._client.RemoveObjectAsync(
                new RemoveObjectArgs()
                    .WithBucket(documentType.ToString())
                    .WithObject(fileId.ToString()));
        }
    }
}
