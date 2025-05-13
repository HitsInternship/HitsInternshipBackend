using DocumentModule.Contracts.CQRS;
using DocumentModule.Contracts.Repositories;
using MediatR;
using System.Web.Mvc;

namespace DocumentModule.Application.Handlers
{
    public class GetDocumentNameQueryHandler : IRequestHandler<GetDocumentNameQuery, string>
    {
        private readonly IFileRepository _fileRepository;
        public GetDocumentNameQueryHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<string> Handle(GetDocumentNameQuery query, CancellationToken cancellationToken)
        {
            return await _fileRepository.GetFileNameAsync(query.documentId, query.documentType);
        }
    }
}
