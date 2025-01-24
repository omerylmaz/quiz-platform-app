using Common.Application.Messaging;
using Common.Domain;
using Quiz.Domain.Categories;

namespace Quiz.Application.Categories.GetCategory;

internal sealed class GetCategoryQueryHandler(ICategoryRepository categoryRepository) : IQueryHandler<GetCategoryQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound(request.CategoryId));
        }

        var response = new CategoryResponse(category.Id, category.Name);

        return response;
    }
}
