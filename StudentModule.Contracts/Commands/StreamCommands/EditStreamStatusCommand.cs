using MediatR;
using StudentModule.Domain.Enums;
using StudentModule.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Contracts.Comands.StreamComands
{
    public record EditStreamStatusCommand() : IRequest<StreamDto>
    {
        public Guid Id { get; set; }
        public StreamStatus Status { get; set; }
    }
}
