using FluentValidation;
using TealHub.Application.DTOs.Questions;

namespace TealHub.Application.Validators;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Question content is required")
            .MinimumLength(10).WithMessage("Question must be at least 10 characters")
            .MaximumLength(1000);

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");
    }
}