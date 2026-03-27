using TealHub.Domain.Entities;

namespace TealHub.Application.Interfaces;

public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetHistoryByUserAsync(Guid userId);
    Task<Question> CreateAsync(Question question);
}