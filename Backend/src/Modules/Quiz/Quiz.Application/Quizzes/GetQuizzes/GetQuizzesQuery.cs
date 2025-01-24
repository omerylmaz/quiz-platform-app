using Common.Application.Messaging;
using Quiz.Application.Quizzes.GetQuiz;

namespace Quiz.Application.Quizzes.GetQuizzes;

public sealed record GetQuizzesQuery : IQuery<IReadOnlyCollection<QuizResponse>>;
