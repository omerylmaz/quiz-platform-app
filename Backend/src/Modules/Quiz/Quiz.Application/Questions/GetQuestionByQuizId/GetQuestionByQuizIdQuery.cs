using Quiz.Application.Messaging;

namespace Quiz.Application.Questions.GetQuestionByQuizId;

public sealed record GetQuestionByQuizIdQuery(Guid QuizId) : IQuery<QuestionResponse>;
