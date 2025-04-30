using DocumentModule.Domain.Entities;
using DocumentModule.Infrastructure;
using Shared.Domain.Entites;
using Shared.Persistence.Repositories;

namespace DocumentModule.Persistence
{
    public class DocumentRepository : BaseEntityEntityRepository<Document>
    {
        public DocumentRepository(DocumentModuleDbContext context) : base(context) { }
    }
}
