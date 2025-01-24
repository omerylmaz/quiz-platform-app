using Quiz.Domain.Abstractions;

namespace Quiz.Domain.Quizzes;

public static class QuizErrors
{
    public static Error NotFound(Guid quizId) =>
    Error.NotFound("Quizzes.NotFound", $"The quiz with the id {quizId} was not found");

}
