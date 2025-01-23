using Quiz.Application.Messaging;
using Quiz.Application.QuizSets.GetQuizSet;

namespace Quiz.Application.QuizSets.GetQuizSetsByUserId;

public sealed record GetQuizSetsByUserIdQuery(Guid UserId) : IQuery<IReadOnlyCollection<QuizSetResponse>>;
