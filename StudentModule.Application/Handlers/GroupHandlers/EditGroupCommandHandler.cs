using MediatR;
using StudentModule.Contracts.Commands.GroupCommands;
using StudentModule.Contracts.DTOs;
using StudentModule.Contracts.Repositories;
using StudentModule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModule.Application.Handlers.GroupHandlers
{
    public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand, GroupDto>
    {
        private readonly IGroupRepository _groupRepository;

        public EditGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<GroupDto> Handle(EditGroupCommand request, CancellationToken cancellationToken)
        {
            GroupEntity? group = await _groupRepository.GetByIdAsync(request.Id);

            if (group == null)
            {
                //todo: добавить обработку исключений
                throw new Exception();
            }

            //todo добавить проверку на занятость
            group.GroupNumber = request.GroupNumber;

            await _groupRepository.UpdateAsync(group);

            return new GroupDto(group);
        }
    }
}
