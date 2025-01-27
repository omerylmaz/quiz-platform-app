using Common.Application.Messaging;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.CreateQuiz;

internal sealed class QuizCreatedDomainEventHandler : IDomainEventHandler<QuizCreatedDomainEvent>
{
    public Task Handle(QuizCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
