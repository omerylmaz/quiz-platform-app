using FluentValidation;

namespace Quiz.Application.Questions.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.Text)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(1000);

        RuleFor(x => x.Answer)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(500);
    }
}
