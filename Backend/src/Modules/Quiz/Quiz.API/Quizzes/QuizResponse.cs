namespace Quiz.API.Quizzes;

public sealed record QuizResponse
    (Guid Id, Guid QuizSetId, string Title, string Description, bool CreatedByAI, string Difficulty);
