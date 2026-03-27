namespace TealHub.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public Guid UploadedByUserId { get; set; }
    public User UploadedBy { get; set; } = null!;

    public ICollection<Source> Sources { get; set; } = new List<Source>();
}