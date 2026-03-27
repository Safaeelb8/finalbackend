namespace TealHub.Application.DTOs.Questions;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime AskedAt { get; set; }
    public Guid UserId { get; set; }
    public string? ResponseContent { get; set; }
}