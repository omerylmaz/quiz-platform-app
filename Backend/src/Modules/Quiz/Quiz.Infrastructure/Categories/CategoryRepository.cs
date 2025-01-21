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

    public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}
