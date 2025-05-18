using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthModel.Infrastructure;
using AuthModel.Service.Interface;
using AuthModule.Contracts.CQRS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Exceptions;
using UserModule.Contracts.Repositories;

namespace AuthModel.Service.Handler;

public class GetRoleHandler :  IRequestHandler<GetRoleQuery, string>
{
    private readonly AuthDbContext context;
    private readonly IRoleRepository roleRepository;
    public GetRoleHandler(IRoleRepository roleRepository, AuthDbContext context)
    {
        this.roleRepository = roleRepository;
        this.context = context;
    }
    
   

    public async Task<string> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetRolesByUserIdAsync(request.UserId);
        if (roles == null || !roles.Any())
        {
            throw new NotFound("Роль для пользователя не найдены");
        }
        
        return roles.First().RoleName.ToString();
    }
}