using StudentModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Contracts.DTOs
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public int GroupNumber { get; set; }
        public Guid StreamId { get; set; }
        public List<Guid>? Students { get; set; }

        public GroupDto() { }

        public GroupDto(GroupEntity group)
        {
            Id = group.Id;
            GroupNumber = group.GroupNumber;
            StreamId = group.StreamId;
            Students = group.Students.Select(student => student.Id).ToList();
        }
    }
}
