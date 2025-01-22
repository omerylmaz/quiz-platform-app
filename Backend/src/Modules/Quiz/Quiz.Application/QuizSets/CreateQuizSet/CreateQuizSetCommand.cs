using Quiz.Application.Messaging;

namespace Quiz.Application.QuizSets.CreateQuizSet;

public sealed record CreateQuizSetCommand(
    string Title,
    string Description,
    Guid UserId,
    List<Guid> CategoryIds
    ) : ICommand<Guid>;
