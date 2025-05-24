using System.Security.Cryptography;
using AuthModel.Service.Interface;
using AuthModule.Contracts.CQRS;
using AuthModule.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using AuthModel.Service.Interface;
using AuthModule.Contracts.CQRS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using UserInfrastructure;

namespace AuthModel.Service.Handler;

public class EditPasswordHandler : IRequestHandler<EditPasswordQuery>
{
    private readonly IHashService hashService;
    private readonly AuthDbContext context;
    public EditPasswordHandler(IHashService hashService, AuthDbContext context)
    {
        this.hashService = hashService;
        this.context = context;
    }
    
    
    public async Task Handle(EditPasswordQuery request, CancellationToken cancellationToken)
    { 
        using SHA256 sha256Hash = SHA256.Create();
        var hash = hashService.GetHash(sha256Hash, request.OldPassword);
        
        var aspNetUser = await context.AspNetUsers.Where(x => x.Id.Equals(request.UserId) && x.Password == hash).FirstOrDefaultAsync();

        if (aspNetUser == null)
        {
            throw new NotFound("aspNetUser not found");
        }
        var newHash = hashService.GetHash(sha256Hash, request.NewPassword);
        aspNetUser.Password = newHash;
        await context.SaveChangesAsync();
    }
}