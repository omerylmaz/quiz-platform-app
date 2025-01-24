using Common.Application.Messaging;
using Quiz.Application.Categories.GetCategory;

namespace Quiz.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
