using System.Security.Cryptography;
using AuthModel.Service.Interface;
using AuthModule.Contracts.CQRS;
using AuthModule.Contracts.Model;
using AuthModule.Domain.Entity;
using MediatR;
using UserInfrastructure;


namespace AuthModel.Service.Handler;

public class CreateAspNetUserHandler : IRequestHandler<CreateAspNetUserQuery, CredInfoDTO>
{
    private readonly IHashService hashService;
    private readonly AuthDbContext context;

    public CreateAspNetUserHandler(IHashService hashService, AuthDbContext context)
    {
        this.hashService = hashService;
        this.context = context;
    }


    public async Task<CredInfoDTO> Handle(CreateAspNetUserQuery request, CancellationToken cancellationToken)
    {
        var genNewAspNetUserDto = new CredInfoDTO()
        {
            UserId = request.UserId,
            Login = request.Email,
            Password = Guid.NewGuid().ToString(),
        };
        using SHA256 sha256Hash = SHA256.Create();

        context.AspNetUsers.Add(new AspNetUser()
        {
            Id = Guid.NewGuid(),
            Login = genNewAspNetUserDto.Login,
            Password = hashService.GetHash(sha256Hash, genNewAspNetUserDto.Password),
            UserId = genNewAspNetUserDto.UserId
        });
        await context.SaveChangesAsync();
        
        return genNewAspNetUserDto;
    }
}