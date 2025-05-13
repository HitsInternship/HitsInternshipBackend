using MediatR;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Queries.StreamQueries;
using StudentModule.Contracts.Repositories;


namespace StudentModule.Application.Handlers.StreamHandlers
{
    public class GetStreamsQueryHandler : IRequestHandler<GetStreamsQuery, List<StreamDto>>
    {
        private readonly IStreamRepository _streamRepository;

        public GetStreamsQueryHandler(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public async Task<List<StreamDto>> Handle(GetStreamsQuery request, CancellationToken cancellationToken)
        {
            var streams = await _streamRepository.GetStreamsAsync();
            List<StreamDto> streamDtos = new List<StreamDto>();

            foreach (var stream in streams)
            {
                streamDtos.Add(new StreamDto(stream));
            }

            return streamDtos;
        }
    }
}
