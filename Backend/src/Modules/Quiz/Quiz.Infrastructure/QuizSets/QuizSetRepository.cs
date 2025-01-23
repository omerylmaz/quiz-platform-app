using Microsoft.EntityFrameworkCore;
using Quiz.Domain.QuizSets;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.QuizSets;

internal sealed class QuizSetRepository(QuizDbContext dbContext) : IQuizSetRepository
{
    public void Add(QuizSet quizSet)
    {
        dbContext.QuizSets.Add(quizSet);
    }

    public async Task<IReadOnlyCollection<QuizSet>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.QuizSets
            .Where(q => q.UserId == userId)
            .Include(q => q.Categories)
            .ToListAsync(cancellationToken);
    }

    public async Task<QuizSet> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.QuizSets
            .Where(q => q.Id == id)
            .Include(q => q.Categories)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
