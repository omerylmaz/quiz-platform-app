using Quiz.Application.Messaging;

namespace Quiz.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
