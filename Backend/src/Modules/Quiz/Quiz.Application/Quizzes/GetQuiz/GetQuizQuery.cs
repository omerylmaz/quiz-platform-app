using MediatR;

namespace Quiz.Application.Quizzes.GetQuiz;

public sealed record GetQuizQuery(Guid QuizId) : IRequest<QuizResponse?>;
