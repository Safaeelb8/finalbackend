namespace TealHub.Domain.Entities;

public class Response
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public ICollection<Source> Sources { get; set; } = new List<Source>();
}