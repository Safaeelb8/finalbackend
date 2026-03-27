using TealHub.Domain.Entities;

namespace TealHub.Application.Interfaces;

public interface ILogRepository
{
    Task<IEnumerable<Log>> GetAllAsync();
    Task<IEnumerable<Log>> GetByUserAsync(Guid userId);
    Task<Log> CreateAsync(Log log);
}