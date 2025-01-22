using Quiz.Application.Categories.GetCategory;
using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;
using Quiz.Domain.Categories;

namespace Quiz.Application.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Category> categories = await categoryRepository.GetAllCategoriesAsync(cancellationToken);

        IReadOnlyCollection<CategoryResponse> response = categories
            .Select(category => new CategoryResponse(category.Id, category.Name))
            .ToList()
            .AsReadOnly();

        return Result.Success(response);
    }
}
