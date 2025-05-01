using DeanModule.Domain.Entities;
using DeanModule.Domain.Enums;
using Shared.Contracts.Repositories;

namespace DeanModule.Contracts.Repositories;

public interface IApplicationRepository : IBaseEntityRepository<Application>
{
    Task<IEnumerable<Application>> GetByStudentIdAsync(Guid studentId);
    Task<IEnumerable<Application>> GetByCompanyId(Guid companyId);
    Task<IEnumerable<Application>> GetByPositionIdAsync(Guid positionId);
    Task<IEnumerable<Application>> GetByStatusAsync(ApplicationStatus status);   
}