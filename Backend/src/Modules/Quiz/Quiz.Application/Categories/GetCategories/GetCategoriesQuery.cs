using Quiz.Application.Categories.GetCategory;
using Quiz.Application.Messaging;

namespace Quiz.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
