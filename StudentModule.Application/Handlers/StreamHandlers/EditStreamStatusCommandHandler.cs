using MediatR;
using StudentModule.Contracts.Comands.StreamComands;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            StreamEntity? stream = await _streamRepository.GetByIdAsync(request.Id);
            if (stream == null)
            {
                //todo: добавить обработку исключений
                throw new Exception();
            }

            stream.Status = request.Status;

            await _streamRepository.UpdateAsync(stream);

            return new StreamDto(stream);
        }
    }
}
