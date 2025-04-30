using Shared.Domain.Entites;

namespace DocumentModule.Domain.Entities
{
    public class Document : BaseEntity
    {
        public Guid? FileId { get; set; }
    }
}
