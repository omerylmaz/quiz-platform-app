using Quiz.Application.Abstractions.Data;
using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;
using Quiz.Domain.Questions;

namespace Quiz.Application.Questions.CreateQuestion;

internal sealed class CreateQuestionCommandHandler(
    IQuestionRepository questionRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateQuestionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = Question.Create(request.QuizId, request.Text);

        questionRepository.Add(question);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return question.Id;
    }
}
