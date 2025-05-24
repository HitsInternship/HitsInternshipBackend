﻿using AuthModule.Contracts.CQRS;
using AutoMapper;
using MediatR;
using Shared.Domain.Exceptions;
using UserModule.Contracts.Commands;
using UserModule.Contracts.Queries;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IMediator mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByEmailAsync(command.createRequest.email) != null) throw new Conflict("User with such email already exists");

            User user = _mapper.Map<User>(command.createRequest);

            await _userRepository.AddAsync(user);

            await _mediator.Send(new CreateAspNetUserQuery() { UserId = user.Id, Email = user.Email });

            return user;
        }
    }
}