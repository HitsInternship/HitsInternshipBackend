using MediatR;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Queries.GroupQueries;
using StudentModule.Contracts.Repositories;
using UserModule.Contracts.Repositories;

namespace StudentModule.Application.Handlers.GroupHandlers
{
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupDto>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public GetGroupsQueryHandler(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }
        public async Task<List<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetGroupAsync();
            var groupDtos = new List<GroupDto>();
            var studentDtos = new List<StudentDto>();

            foreach (var group in groups)
            {
                studentDtos = new List<StudentDto>();
                foreach (var student in group.Students)
                {
                    var user = await _userRepository.GetByIdAsync(student.UserId);
                    student.User = user;
                    studentDtos.Add(new StudentDto(student));
                }

                var groupDto = new GroupDto(group);
                groupDto.Students = studentDtos;
                groupDtos.Add(groupDto);
            }

            return groupDtos;
        }
    }
}
