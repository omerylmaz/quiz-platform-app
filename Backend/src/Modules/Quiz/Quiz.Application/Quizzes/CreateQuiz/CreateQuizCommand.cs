using MediatR;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.CreateQuiz;

public sealed record CreateQuizCommand(
    Guid QuizSetId,
    string Title,
    string Description,
    QuizDifficulty Difficulty,
    bool CreatedByAI) : IRequest<Guid>;
