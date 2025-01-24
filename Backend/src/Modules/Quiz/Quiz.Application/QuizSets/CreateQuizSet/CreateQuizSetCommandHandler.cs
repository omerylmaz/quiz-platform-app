using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
using Quiz.Domain.Categories;
using Quiz.Domain.QuizSets;

namespace Quiz.Application.QuizSets.CreateQuizSet;

internal sealed class CreateQuizSetCommandHandler(
    IQuizSetRepository quizSetRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateQuizSetCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateQuizSetCommand request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Category> categories = await categoryRepository.GetAllCategoriesWhereAsync(c => request.CategoryIds.Contains(c.Id), cancellationToken);

        var quizSet = QuizSet.Create(request.Title, request.Description, request.UserId, [.. categories]);

        quizSetRepository.Add(quizSet);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return quizSet.Id;
    }
}
