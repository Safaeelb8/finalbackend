using Microsoft.EntityFrameworkCore;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Repositories;

public class LogRepository : ILogRepository
{
    private readonly AppDbContext _context;

    public LogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Log>> GetAllAsync() =>
        await _context.Logs.Include(l => l.User)
            .OrderByDescending(l => l.Timestamp).ToListAsync();

    public async Task<IEnumerable<Log>> GetByUserAsync(Guid userId) =>
        await _context.Logs.Where(l => l.UserId == userId)
            .OrderByDescending(l => l.Timestamp).ToListAsync();

    public async Task<Log> CreateAsync(Log log)
    {
        _context.Logs.Add(log);
        await _context.SaveChangesAsync();
        return log;
    }
}