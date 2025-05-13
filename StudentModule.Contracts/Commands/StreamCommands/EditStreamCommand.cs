using StudentModule.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModule.Domain.Enums;

namespace StudentModule.Contracts.Comands.StreamComands
{
    public record EditStreamCommand() : IRequest<StreamDto>
    {
        public Guid Id { get; set; }
        public int StreamNumber { get; set; }
        public int Year { get; set; }
        public StreamStatus Status { get; set; }
    }
}
