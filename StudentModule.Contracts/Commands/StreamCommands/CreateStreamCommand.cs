using MediatR;
using StudentModule.Contracts.DTOs;
using StudentModule.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Contracts.Comands.StreamComands
{
    public record CreateStreamCommand() : IRequest<StreamDto>
    {
        public int StreamNumber { get; set; }
        public int Year { get; set; }
        public StreamStatus Status { get; set; }
    }
}
