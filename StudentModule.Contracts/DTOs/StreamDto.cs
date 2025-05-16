using StudentModule.Domain.Entities;
using StudentModule.Domain.Enums;


namespace StudentModule.Contracts.DTOs
{
    public class StreamDto
    {
        public Guid id { get; set; }
        public int streamNumber { get; set; }
        public int year { get; set; }
        public StreamStatus status { get; set; }
        public List<GroupDto> groups { get; set; }

        public StreamDto() { }

        public StreamDto(StreamEntity stream)
        {
            id = stream.Id;
            streamNumber = stream.StreamNumber;
            year = stream.Year;
            status = stream.Status;
            /*groups = stream.Groups
                    .Select(g => new GroupDto(g))
                    .ToList();*/
        }
    }
}
