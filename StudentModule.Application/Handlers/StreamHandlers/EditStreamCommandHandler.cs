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
    public class EditStreamCommandHandler : IRequestHandler<EditStreamCommand, StreamDto>
    {
        private readonly IStreamRepository _streamRepository;

        public EditStreamCommandHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<StreamDto> Handle(EditStreamCommand request, CancellationToken cancellationToken)
        {
            StreamEntity? stream = await _streamRepository.GetByIdAsync(request.Id) 
                ?? throw new NotFound("Stream not found");
            
            if (await _streamRepository.IsStreamWithNumderExistsAsync(request.StreamNumber))
                throw new Conflict($"Stream with number {request.StreamNumber} already exists");

            if (request.Year < 2017 || request.Year > DateTime.Now.Year)
                throw new BadRequest("Invalid year");
            

            stream.StreamNumber = request.StreamNumber;
            stream.Status = request.Status;
            stream.Year = request.Year;

            await _streamRepository.UpdateAsync(stream);

            return new StreamDto(stream);
        }
    }
}
