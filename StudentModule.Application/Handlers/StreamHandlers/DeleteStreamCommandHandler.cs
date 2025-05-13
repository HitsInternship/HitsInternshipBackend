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
    public class DeleteStreamCommandHandler : IRequestHandler<DeleteStreamCommand, Unit>
    {
        private readonly IStreamRepository _streamRepository;

        public DeleteStreamCommandHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<Unit> Handle(DeleteStreamCommand request, CancellationToken cancellationToken)
        {
            StreamEntity? stream = await _streamRepository.GetByIdAsync(request.StreamId);

            if (stream == null)
            {
                //todo: добавить обработку исключений
                throw new Exception();
            }

            await _streamRepository.DeleteAsync(stream);

            return Unit.Value;
        }
    }
}
