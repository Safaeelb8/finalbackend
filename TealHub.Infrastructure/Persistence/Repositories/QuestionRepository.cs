using Microsoft.EntityFrameworkCore;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Question?> GetByIdAsync(Guid id) =>
        await _context.Questions.Include(q => q.Response).FirstOrDefaultAsync(q => q.Id == id);

    public async Task<IEnumerable<Question>> GetHistoryByUserAsync(Guid userId) =>
        await _context.Questions
            .Include(q => q.Response)
            .Where(q => q.UserId == userId)
            .OrderByDescending(q => q.AskedAt)
            .ToListAsync();

    public async Task<Question> CreateAsync(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }
}