using Common.Application.Messaging;
using Quiz.Application.Questions.GetQuestionByQuizId;

namespace Quiz.Application.Questions.GetQuestionsByQuizId;

public sealed record GetQuestionsByQuizIdQuery(Guid QuizId) : IQuery<IReadOnlyCollection<QuestionResponse>>;
