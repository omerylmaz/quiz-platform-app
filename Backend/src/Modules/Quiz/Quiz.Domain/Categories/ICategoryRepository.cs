namespace Quiz.Domain.Categories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Category category);
}
