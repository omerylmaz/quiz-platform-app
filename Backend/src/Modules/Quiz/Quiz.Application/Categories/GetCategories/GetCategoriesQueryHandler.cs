using Common.Application.Caching;
using Common.Application.Messaging;
using Common.Domain;
using Quiz.Application.Categories.GetCategory;
using Quiz.Domain.Categories;
using static Quiz.Application.Constants;

namespace Quiz.Application.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler(ICategoryRepository categoryRepository,
    ICacheService cacheService)
    : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        List<CategoryResponse> categories = await cacheService.GetAsync<List<CategoryResponse>>("categories");
        if (categories is not null)
            return categories;

        IReadOnlyCollection<Category> categoriesDb = await categoryRepository.GetAllCategoriesAsync(cancellationToken);

        List<CategoryResponse> response = categoriesDb
            .Select(category => new CategoryResponse(category.Id, category.Name))
            .ToList();

        await cacheService.SetAsync(CacheNames.CATEGORIES, response);

        return response;
    }
}
