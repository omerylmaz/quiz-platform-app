using Common.Domain;
using Quiz.Domain.Categories;

namespace Quiz.Domain.QuizSets;

public sealed class QuizSet : Entity
{
    private QuizSet() { }

    public Guid Id { get; private set; }

    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public Guid UserId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public ICollection<Category> Categories { get; private set; }

    public static QuizSet Create(string title, string description, Guid userId, ICollection<Category> categories)
    {
        var quizSet = new QuizSet()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Categories = categories
        };

        return quizSet;
    }
}
