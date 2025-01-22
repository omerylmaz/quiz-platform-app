using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.GetQuiz;

public sealed record QuizResponse
    (Guid Id, Guid QuizSetId, string Title, string Description, bool CreatedByAI, QuizDifficulty Difficulty);
