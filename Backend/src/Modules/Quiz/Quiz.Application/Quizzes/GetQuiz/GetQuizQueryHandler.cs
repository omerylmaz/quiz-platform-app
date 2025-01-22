using MediatR;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.GetQuiz;

internal sealed class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, QuizResponse?>
{
    private readonly IQuizRepository _quizRepository;

    public GetQuizQueryHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<QuizResponse?> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        Domain.Quizzes.Quiz? quiz = await _quizRepository.GetAsync(request.QuizId, cancellationToken);

        if (quiz is null)
            return null;

        return new QuizResponse(
            quiz.Id,
            quiz.QuizSetId,
            quiz.Title ?? string.Empty,
            quiz.Description ?? string.Empty,
            quiz.CreatedByAI,
            quiz.Difficulty
        );
    }
}
