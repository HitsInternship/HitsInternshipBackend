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
    public class EditStreamCommandHandler : IRequestHandler<EditStreamCommand, StreamDto>
    {
        private readonly IStreamRepository _streamRepository;

        public EditStreamCommandHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<StreamDto> Handle(EditStreamCommand request, CancellationToken cancellationToken)
        {
            StreamEntity? stream = await _streamRepository.GetByIdAsync(request.Id);
            if (stream == null)
            {
                //todo: добавить обработку исключений
                throw new Exception();
            } 

            //todo: добавить проверки на занятость номера и валидность года
            // добавить присобачивание групп

            stream.StreamNumber = request.StreamNumber;
            stream.Status = request.Status;
            stream.Year = request.Year;

            await _streamRepository.UpdateAsync(stream);

            return new StreamDto(stream);
        }
    }
}
