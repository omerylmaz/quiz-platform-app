using Quiz.Application.Messaging;

namespace Quiz.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
