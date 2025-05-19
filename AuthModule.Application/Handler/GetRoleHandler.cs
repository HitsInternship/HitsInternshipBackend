using AuthModule.Contracts.CQRS;
using MediatR;
using Shared.Domain.Exceptions;
using UserModule.Contracts.Repositories;

namespace AuthModel.Service.Handler;

public class GetRoleHandler : IRequestHandler<GetRoleQuery, string>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }


    public async Task<string> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetRolesByUserIdAsync(request.UserId);
        if (roles == null || !roles.Any())
        {
            throw new NotFound("Роль для пользователя не найдены");
        }

        return roles.First().RoleName.ToString();
    }
}