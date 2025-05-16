using MediatR;
using StudentModule.Contracts.Commands.StudentCommands;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using UserModule.Contracts.Repositories;

namespace StudentModule.Application.Handlers.StudentHandlres
{
    public class EditStudentStatusCommandHandler : IRequestHandler<EditStudentStatusCommand, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;

        public EditStudentStatusCommandHandler(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public async Task<StudentDto> Handle(EditStudentStatusCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            var user = await _userRepository.GetByIdAsync(student.UserId);

            //todo добавить проверку на существование студента

            student.Status = request.Status;
            await _studentRepository.UpdateAsync(student);

            student.User = user;
            return new StudentDto(student);
        }
    }
}
