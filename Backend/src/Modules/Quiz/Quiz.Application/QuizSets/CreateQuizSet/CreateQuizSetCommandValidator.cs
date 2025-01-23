using FluentValidation;

namespace Quiz.Application.QuizSets.CreateQuizSet;

internal sealed class CreateQuizSetCommandValidator : AbstractValidator<CreateQuizSetCommand>
{
    public CreateQuizSetCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.CategoryIds)
            .NotNull()
            .Must(ids => ids.Any())
            .ForEach(id =>
            {
                id.NotEmpty()
                   .NotEqual(Guid.Empty);
            });
    }
}
