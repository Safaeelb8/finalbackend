namespace TealHub.Application.DTOs.Questions;

public class CreateQuestionDto
{
    public string Content { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}