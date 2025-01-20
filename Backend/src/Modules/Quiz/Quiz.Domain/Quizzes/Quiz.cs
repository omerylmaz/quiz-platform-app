namespace Quiz.Domain.Quizzes;

public sealed class Quiz
{
    public Guid Id { get; set; }

    public Guid QuizSetId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool CreatedByAI { get; set; }

    public QuizDifficulty Difficulty { get; set; }

    public DateTime CreatedAt { get; set; }
}
