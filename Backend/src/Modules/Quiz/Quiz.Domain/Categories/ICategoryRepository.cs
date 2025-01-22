using System.Linq.Expressions;

namespace Quiz.Domain.Categories;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Category>> GetAllCategoriesWhereAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default);

    void Add(Category category);
}
