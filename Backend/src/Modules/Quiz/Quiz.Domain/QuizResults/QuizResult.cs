using Quiz.Domain.Abstractions;

namespace Quiz.Domain.QuizResults;

public class QuizResult : Entity
{
    private QuizResult() { }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid QuizSetId { get; private set; }

    public int Score { get; private set; }

    public DateTime CompletionDate { get; private set; }


    public static QuizResult Create(Guid userId, Guid quizSetId, int score, DateTime completionDate)
    {
        return new QuizResult
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            QuizSetId = quizSetId,
            Score = score,
            CompletionDate = completionDate
        };
    }
}
