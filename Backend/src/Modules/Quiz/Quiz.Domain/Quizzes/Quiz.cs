using Common.Domain;

namespace Quiz.Domain.Quizzes;

public sealed class Quiz : Entity
{
    private Quiz()
    {
    }

    public Guid Id { get; private set; }

    public Guid QuizSetId { get; private set; }

    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public bool CreatedByAI { get; private set; }

    public QuizDifficulty Difficulty { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Quiz Create(
        Guid quizSetId,
        string title,
        string description,
        bool createdByAI,
        QuizDifficulty quizDifficulty
        )
    {
        var quiz = new Quiz()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            QuizSetId = quizSetId,
            Difficulty = quizDifficulty,
            CreatedByAI = createdByAI,
            CreatedAt = DateTime.UtcNow
        };

        quiz.Raise(new QuizCreatedDomainEvent(quiz.Id));

        return quiz;
    }
}
