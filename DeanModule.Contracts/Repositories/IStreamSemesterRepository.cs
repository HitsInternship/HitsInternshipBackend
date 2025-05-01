using DeanModule.Domain.Entities;
using Shared.Contracts.Repositories;

namespace DeanModule.Contracts.Repositories;

public interface IStreamSemesterRepository : IBaseEntityRepository<StreamSemester>
{
    Task<IEnumerable<StreamSemester?>> GetByStreamIdAsync(Guid streamId);
    Task<StreamSemester?> GetBySemesterIdAsync(Guid semesterId, int semesterNumber);
}