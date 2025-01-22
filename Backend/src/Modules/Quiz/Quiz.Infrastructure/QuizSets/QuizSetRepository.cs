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

    public async Task<QuizSet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.QuizSets
            .Include(q => q.Categories)
            .FirstOrDefaultAsync(q => q.UserId == userId, cancellationToken);
    }
}
