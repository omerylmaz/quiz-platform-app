using Common.Application.Messaging;
using Common.Domain;
using Quiz.Application.Abstractions.Data;
using Quiz.Domain.Categories;

namespace Quiz.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        categoryRepository.Add(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
