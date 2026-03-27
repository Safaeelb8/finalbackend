using TealHub.Domain.Entities;

namespace TealHub.Application.Interfaces;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id);
    Task<IEnumerable<Document>> GetAllAsync();
    Task<IEnumerable<Document>> SearchAsync(string keyword);
    Task<IEnumerable<Document>> GetByUserAsync(Guid userId);
    Task<Document> CreateAsync(Document document);
    Task DeleteAsync(Guid id);
}