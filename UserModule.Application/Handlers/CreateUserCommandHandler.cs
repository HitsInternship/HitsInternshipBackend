using AutoMapper;
using MediatR;
using Shared.Domain.Exceptions;
using UserModule.Contracts.CQRS;
using UserModule.Contracts.DTOs;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByEmailAsync(command.createRequest.email) != null) throw new Conflict("User with such email already exists");

            //List<Role> roles = await _roleRepository.GetRolesAsync(command.createRequest.roles);

            User user = _mapper.Map<User>(command.createRequest);
            //user.Roles = roles;

            await _userRepository.AddAsync(user);

            return user;
        }
    }
}
