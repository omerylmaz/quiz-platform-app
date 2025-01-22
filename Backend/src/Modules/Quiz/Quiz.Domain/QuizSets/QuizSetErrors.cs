using Quiz.Domain.Abstractions;

namespace Quiz.Domain.QuizSets;

public static class QuizSetErrors
{
    public static Error NotFoundByUserId(Guid userId) =>
    Error.NotFound("QuizSet.NotFound", $"The quiz set with the user id {userId} was not found");

}
