using FluentValidation;
using TealHub.Application.DTOs.Documents;

namespace TealHub.Application.Validators;

public class UploadDocumentValidator : AbstractValidator<UploadDocumentDto>
{
    public UploadDocumentValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200);

        RuleFor(x => x.FilePath)
            .NotEmpty().WithMessage("File path is required");

        RuleFor(x => x.FileSize)
            .GreaterThan(0).WithMessage("File size must be greater than 0");

        RuleFor(x => x.UploadedByUserId)
            .NotEmpty().WithMessage("Uploader ID is required");
    }
}