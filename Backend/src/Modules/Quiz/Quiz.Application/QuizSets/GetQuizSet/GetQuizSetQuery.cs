using Quiz.Application.Messaging;

namespace Quiz.Application.QuizSets.GetQuizSet;

public sealed record GetQuizSetQuery(Guid UserId) : IQuery<QuizSetResponse>;
