using MediatR;
using Shared.Domain.Exceptions;
using StudentModule.Contracts.Commands.StudentCommands;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;
using UserModule.Domain.Enums;

namespace StudentModule.Application.Handlers.StudentHandlres
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IGroupRepository _groupRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IUserRepository userRepository, IRoleRepository roleRepository, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _groupRepository = groupRepository;
        }
        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            User user;
            if (request.userId != null)
            {
                user = await _userRepository.GetByIdAsync((Guid)request.userId)
                    ?? throw new NotFound("User not found");
            }

            else
            {
                user = new User()
                {
                    Name = request.userRequest.name,
                    Surname = request.userRequest.surname,
                    Email = request.userRequest.email
                };
                user.Roles.Add(await _roleRepository.GetRoleAsync(RoleName.Student ));
                await _userRepository.AddAsync(user);
            }

            var group = await _groupRepository.GetByIdAsync(request.GroupId)
                ?? throw new NotFound("Group not found");

            StudentEntity student = new StudentEntity()
            {
                UserId = user.Id,
                User = user,
                Middlename = request.Middlename,
                Phone = request.Phone,
                IsHeadMan = request.IsHeadMan,
                Status = request.Status,
                GroupId = request.GroupId,
                Group = group
            };

            await _studentRepository.AddAsync(student);

            return new StudentDto(student);
        }
    }
}