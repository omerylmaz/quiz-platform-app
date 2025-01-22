namespace Quiz.Domain.Questions;

public class Choice
{
    private Choice() { }

    public Guid Id { get; private set; }
    public Guid QuestionId { get; private set; }
    public string Text { get; private set; }
    public bool IsCorrect { get; private set; }

    public static Choice Create(Guid questionId, string text, bool isCorrect)
    {
        return new Choice
        {
            Id = Guid.NewGuid(),
            QuestionId = questionId,
            Text = text,
            IsCorrect = isCorrect
        };
    }
}
