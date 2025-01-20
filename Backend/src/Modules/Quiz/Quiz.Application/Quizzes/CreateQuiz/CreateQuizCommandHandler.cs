using MediatR;
using Quiz.Application.Abstractions.Data;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.CreateQuiz;

internal sealed class CreateQuizCommandHandler(
    IQuizRepository quizRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateQuizCommand, Guid>
{
    public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        Domain.Quizzes.Quiz quiz = new()
        {
            CreatedAt = DateTime.UtcNow,
            CreatedByAI = request.CreatedByAI,
            Description = request.Description,
            Difficulty = request.Difficulty,
            QuizSetId = request.QuizSetId,
            Title = request.Title,
            Id = Guid.NewGuid(),
        };

        quizRepository.Add(quiz);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return quiz.Id;
    }
}
