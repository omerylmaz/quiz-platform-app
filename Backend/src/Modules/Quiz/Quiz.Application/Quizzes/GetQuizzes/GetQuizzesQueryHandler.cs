using Quiz.Application.Messaging;
using Quiz.Application.Quizzes.GetQuiz;
using Quiz.Domain.Abstractions;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.GetQuizzes;

internal sealed class GetQuizzesQueryHandler : IQueryHandler<GetQuizzesQuery, IReadOnlyCollection<QuizResponse>>
{
    private readonly IQuizRepository _quizRepository;

    public GetQuizzesQueryHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<Result<IReadOnlyCollection<QuizResponse>>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Domain.Quizzes.Quiz> quizzes = await _quizRepository.GetAllQuizzesAsync(cancellationToken);

        IReadOnlyCollection<QuizResponse> response = quizzes
            .Select(quiz => new QuizResponse(
                quiz.Id,
                quiz.QuizSetId,
                quiz.Title ?? string.Empty,
                quiz.Description ?? string.Empty,
                quiz.CreatedByAI,
                quiz.Difficulty
            ))
            .ToList();

        return Result.Success(response);
    }
}
