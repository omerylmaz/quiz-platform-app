using Common.Application.Messaging;
using Common.Domain;
using Quiz.Application.Questions.GetQuestionByQuizId;
using Quiz.Domain.Questions;

namespace Quiz.Application.Questions.GetQuestionsByQuizId;

internal sealed class GetQuestionsByQuizIdQueryHandler : IQueryHandler<GetQuestionsByQuizIdQuery, IReadOnlyCollection<QuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionsByQuizIdQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Result<IReadOnlyCollection<QuestionResponse>>> Handle(GetQuestionsByQuizIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Question> questions = await _questionRepository.GetQuestionsByQuizIdAsync(request.QuizId, cancellationToken);

        var questionResponses = questions.Select(q => new QuestionResponse(
            q.Id,
            q.QuizId,
            q.Text,
            q.Choices.Select(c => new ChoiceResponse(
                c.Id,
                c.QuestionId,
                c.Text,
                c.IsCorrect
            )).ToList().AsReadOnly()
        )).ToList();

        return Result.Success<IReadOnlyCollection<QuestionResponse>>(questionResponses.AsReadOnly());
    }
}
