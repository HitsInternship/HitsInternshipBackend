using Shared.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModule.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string Name { get; set; }
        public Guid DocumentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
