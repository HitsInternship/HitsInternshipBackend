using Shared.Domain.Entites;
using StudentModule.Domain.Enums;


namespace StudentModule.Domain.Entities
{
    public class StreamEntity : BaseEntity
    {
        public int StreamNumber { get; set; }
        public int Year { get; set; }
        public StreamStatus Status { get; set; }

        public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();
    }
}
