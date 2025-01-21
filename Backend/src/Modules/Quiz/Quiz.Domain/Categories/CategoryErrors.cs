using Quiz.Domain.Abstractions;

namespace Quiz.Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound(Guid categoryId) =>
        Error.NotFound("Categories.NotFound", $"The category with the id {categoryId} was not found");
}
