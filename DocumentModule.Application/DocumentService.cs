using DocumentModule.Domain.Entities;
using DocumentModule.Persistence;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace DocumentModule.Application
{
    public class DocumentService
    {
        private readonly DocumentRepository documentRepository;
        private readonly FileRepository fileRepository;

        public DocumentService(DocumentRepository documentRepository, FileRepository fileRepository)
        {
            this.documentRepository = documentRepository;
            this.fileRepository = fileRepository;
        }

        public async Task CreateDocument(Document Document)
        {
            await documentRepository.AddAsync(Document);
        }

        public async Task GetDocument(Guid DocumentId)
        {
            await documentRepository.GetByIdAsync(DocumentId);
        }

        public async Task DeleteDocument(Document Document)
        {
            await documentRepository.DeleteAsync(Document);
        }



        public async Task UploadDocumentFile(Document Document, IFormFile File)
        {
            Document.FileId = Guid.NewGuid();

            await fileRepository.AddFileAsync((Guid)Document.FileId, File);
            await documentRepository.UpdateAsync(Document);
        }

        public async Task<FileContentResult?> GetDocumentFile(Document Document)
        {
            if (Document.FileId == null) return null;
            else return await fileRepository.GetFileAsync((Guid)Document.FileId);
        }

        public async Task DeleteDocumentFile(Document Document)
        {
            await fileRepository.DeleteFileAsync((Guid)Document.FileId);
        }
    }
}
