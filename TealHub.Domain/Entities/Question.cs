namespace TealHub.Domain.Entities;

public class Question
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime AskedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Response? Response { get; set; }
}