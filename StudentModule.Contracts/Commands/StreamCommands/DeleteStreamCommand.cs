using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Contracts.Comands.StreamComands
{
    public record DeleteStreamCommand : IRequest<Unit>
    {
        public Guid StreamId { get; set; }
    }
}
