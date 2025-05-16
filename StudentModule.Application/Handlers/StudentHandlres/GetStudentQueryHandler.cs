using MediatR;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Queries.StudentQueries;
using StudentModule.Contracts.Repositories;
using UserModule.Contracts.Repositories;

namespace StudentModule.Application.Handlers.StudentHandlres
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        public GetStudentQueryHandler(IStudentRepository studentRepository, IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.id);
            var user = await _userRepository.GetByIdAsync(student.UserId);
            var group = await _groupRepository.GetByIdAsync(student.GroupId);

            student.User = user;
            student.Group = group;
            return new StudentDto(student);
        }
    }
}
