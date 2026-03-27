namespace TealHub.Application.DTOs.Documents;

public class UploadDocumentDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public Guid UploadedByUserId { get; set; }
}