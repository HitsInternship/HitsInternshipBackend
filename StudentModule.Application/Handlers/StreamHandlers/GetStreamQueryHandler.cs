using MediatR;
using Shared.Domain.Exceptions;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Queries.StreamQueries;
using StudentModule.Contracts.Repositories;

using UserModule.Contracts.Repositories;

namespace StudentModule.Application.Handlers.StreamHandlers
{
    public class GetStreamQueryHandler : IRequestHandler<GetStreamQuery, StreamDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStreamRepository _streamRepository;

        public GetStreamQueryHandler(IUserRepository userRepository, IStreamRepository streamRepository)
        {
            _userRepository = userRepository;
            _streamRepository = streamRepository;
        }

        public async Task<StreamDto> Handle(GetStreamQuery request, CancellationToken cancellationToken)
        {
            var stream = await _streamRepository.GetStreamByIdAsync(request.streamId)
                ?? throw new NotFound("Stream not found");

            var groups = new List<GroupDto>();
            var students = new List<StudentDto>();

            foreach (var group in stream.Groups)
            {
                students = new List<StudentDto>();
                foreach (var student in group.Students)
                {
                    var user = await _userRepository.GetByIdAsync(student.UserId);
                    student.User = user;
                    students.Add(new StudentDto(student));
                }

                var groupDto = new GroupDto(group);
                groupDto.Students = students;
                groups.Add(groupDto);
            }

            var streamDto = new StreamDto(stream);
            streamDto.groups = groups;

            return streamDto;
        }
    }
}
