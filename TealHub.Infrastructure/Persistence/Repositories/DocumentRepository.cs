using Microsoft.EntityFrameworkCore;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly AppDbContext _context;

    public DocumentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Document?> GetByIdAsync(Guid id) =>
        await _context.Documents.Include(d => d.UploadedBy).FirstOrDefaultAsync(d => d.Id == id);

    public async Task<IEnumerable<Document>> GetAllAsync() =>
        await _context.Documents.Include(d => d.UploadedBy).ToListAsync();

    public async Task<IEnumerable<Document>> SearchAsync(string keyword) =>
        await _context.Documents
            .Where(d => d.Title.Contains(keyword) || d.Description.Contains(keyword))
            .ToListAsync();

    public async Task<IEnumerable<Document>> GetByUserAsync(Guid userId) =>
        await _context.Documents.Where(d => d.UploadedByUserId == userId).ToListAsync();

    public async Task<Document> CreateAsync(Document document)
    {
        _context.Documents.Add(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task DeleteAsync(Guid id)
    {
        var doc = await _context.Documents.FindAsync(id);
        if (doc != null)
        {
            _context.Documents.Remove(doc);
            await _context.SaveChangesAsync();
        }
    }
}
