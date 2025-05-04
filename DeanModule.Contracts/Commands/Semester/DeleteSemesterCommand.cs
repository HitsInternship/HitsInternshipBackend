using MediatR;

namespace DeanModule.Contracts.Commands.Semester;

public record DeleteSemesterCommand(Guid SemesterId) : IRequest<Unit>;