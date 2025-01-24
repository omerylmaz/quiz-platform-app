using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
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
