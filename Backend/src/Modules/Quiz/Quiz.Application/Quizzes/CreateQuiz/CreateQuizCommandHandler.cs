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
        var quiz = Domain.Quizzes.Quiz.Create(
            request.QuizSetId,
            request.Title,
            request.Description,
            request.CreatedByAI,
            request.Difficulty);


        quizRepository.Add(quiz);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return quiz.Id;
    }
}
