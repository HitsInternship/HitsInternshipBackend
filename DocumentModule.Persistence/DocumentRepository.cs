using DocumentModule.Domain.Entities;
using DocumentModule.Infrastructure;
using Shared.Persistence.Repositories;

namespace DocumentModule.Persistence
{
    public class DocumentRepository : BaseEntityRepository<Document>
    {
        public DocumentRepository(DocumentModuleDbContext context) : base(context) { }
    }
}
