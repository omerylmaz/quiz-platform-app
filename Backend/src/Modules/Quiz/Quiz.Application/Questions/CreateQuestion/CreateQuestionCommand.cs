using Common.Application.Messaging;

namespace Quiz.Application.Questions.CreateQuestion;

public sealed record CreateQuestionCommand(
    Guid QuizId,
    string Text,
    string Answer
    ) : ICommand<Guid>;
