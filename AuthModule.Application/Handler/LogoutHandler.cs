using AuthModule.Contracts.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using UserInfrastructure;

namespace AuthModel.Service.Handler;

public class LogoutHandler : IRequestHandler<LogoutDTO, Unit>
{
    private readonly AuthDbContext context;

    public LogoutHandler(AuthDbContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(LogoutDTO request, CancellationToken cancellationToken)
    {
        var user = await context.AspNetUsers
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFound("Пользователь не найден");
        }

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.MinValue;

        await context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
