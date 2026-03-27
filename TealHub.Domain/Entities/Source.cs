namespace TealHub.Domain.Entities;

public class Source
{
    public Guid Id { get; set; }
    public string Excerpt { get; set; } = string.Empty;
    public int PageNumber { get; set; }

    // Foreign keys
    public Guid DocumentId { get; set; }
    public Document Document { get; set; } = null!;

    public Guid ResponseId { get; set; }
    public Response Response { get; set; } = null!;
}