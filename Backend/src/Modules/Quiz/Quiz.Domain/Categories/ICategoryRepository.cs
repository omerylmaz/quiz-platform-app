namespace Quiz.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Category category);
}
