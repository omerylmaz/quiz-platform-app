using Quiz.Domain.Abstractions;

namespace Quiz.Domain.Questions;
public static class QuestionErrors
{
    public static Error NotFound(Guid questionId) =>
        Error.NotFound("Questions.NotFound", $"The question with the id {questionId} was not found");
}
