using MediatR;
using Shared.Domain.Exceptions;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModule.Contracts.Commands.StreamCommands;

namespace StudentModule.Application.Handlers.StreamHandlers
{
    public class EditStreamStatusCommandHandler : IRequestHandler<EditStreamStatusCommand, StreamDto>
    {
        private readonly IStreamRepository _streamRepository;

        public EditStreamStatusCommandHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<StreamDto> Handle(EditStreamStatusCommand request, CancellationToken cancellationToken)
        { 
            StreamEntity? stream = await _streamRepository.GetByIdAsync(request.Id) 
                ?? throw new NotFound("Stream not found");


            stream.Status = request.Status;

            await _streamRepository.UpdateAsync(stream);

            return new StreamDto(stream);
        }
    }
}
