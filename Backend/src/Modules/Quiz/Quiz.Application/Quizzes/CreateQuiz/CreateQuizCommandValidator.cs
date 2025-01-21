using FluentValidation;

namespace Quiz.Application.Quizzes.CreateQuiz;

internal sealed class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(x => x.QuizSetId)
            .NotEmpty()
            .Must(id => id != Guid.Empty);

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Difficulty)
            .IsInEnum();

    }
}
