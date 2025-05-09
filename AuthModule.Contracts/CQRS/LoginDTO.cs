using MediatR;

namespace AuthModule.Contracts.CQRS;

public record LoginDTO : IRequest<string>
{
  public string Login { get; init; }
  public string Password { get; init; }
}