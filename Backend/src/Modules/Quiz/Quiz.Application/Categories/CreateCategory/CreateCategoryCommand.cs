using Common.Application.Messaging;

namespace Quiz.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
