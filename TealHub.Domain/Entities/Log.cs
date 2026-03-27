namespace TealHub.Domain.Entities;

public class Log
{
    public Guid Id { get; set; }
    public string Action { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string IpAddress { get; set; } = string.Empty;

    // Foreign key
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}