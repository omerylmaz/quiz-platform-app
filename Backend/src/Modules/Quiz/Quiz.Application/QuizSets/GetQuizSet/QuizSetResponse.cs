namespace Quiz.Application.QuizSets.GetQuizSet;

public sealed record QuizSetResponse(
    Guid Id,
    string Title,
    string Description,
    List<string> Categories
    );
