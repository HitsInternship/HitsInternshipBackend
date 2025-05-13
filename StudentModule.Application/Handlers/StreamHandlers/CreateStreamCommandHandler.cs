using MediatR;
using StudentModule.Contracts.Comands.StreamComands;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;

namespace StudentModule.Application.Handlers.StreamHandlers
{
    public class CreateStreamCommandHandler : IRequestHandler<CreateStreamCommand, StreamDto>
    {
        private readonly IStreamRepository _streamRepository;

        public CreateStreamCommandHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<StreamDto> Handle(CreateStreamCommand request, CancellationToken cancellationToken)
        {
            //todo: добавить обработку исключений


            StreamEntity stream = new StreamEntity()
            {
                StreamNumber = request.StreamNumber,
                Year = request.Year,
                Status = request.Status,
            };

            await _streamRepository.AddAsync(stream);

            return new StreamDto(stream);
        }
    }
}
