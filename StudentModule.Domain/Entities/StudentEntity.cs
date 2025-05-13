using Shared.Domain.Entites;
using StudentModule.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Domain.Entities
{
    public class StudentEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsHeadMan { get; set; }
        public StudentStatus Status { get; set; }

        public Guid GroupId { get; set; }
        public GroupEntity Group { get; set; }
    }
}
