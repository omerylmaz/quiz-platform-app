using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Categories;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.Categories;
internal sealed class CategoryRepository(QuizDbContext dbContext) : ICategoryRepository
{
    public void Add(Category category)
    {
        dbContext.Categories.Add(category);
    }

    public async Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Category>> GetAllCategoriesWhereAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}
