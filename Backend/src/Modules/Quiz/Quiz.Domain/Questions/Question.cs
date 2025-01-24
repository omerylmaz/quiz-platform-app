using Common.Domain;

namespace Quiz.Domain.Questions;

public class Question : Entity
{
    private readonly List<Choice> _choices = [];

    private Question() { }

    public Guid Id { get; private set; }

    public Guid QuizId { get; private set; }

    public string Text { get; private set; }

    public IReadOnlyCollection<Choice> Choices => [.. _choices];

    public static Question Create(Guid quizId, string text)
    {
        var question = new Question()
        {
            Id = quizId,
            Text = text
        };

        return question;
    }

    public void ChangeQuestion(string text)
    {
        if (Text == text)
            return;

        Text = text;
    }

    public void AddChoice(string text, bool isCorrect)
    {
        // allowed multiple true choices
        var choice = Choice.Create(Id, text, isCorrect);

        _choices.Add(choice);
    }
}
