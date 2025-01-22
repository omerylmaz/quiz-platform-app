using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Quizzes;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.Quizzes;

internal sealed class QuizRepository(QuizDbContext dbContext) : IQuizRepository
{
    public void Add(Domain.Quizzes.Quiz quiz)
    {
        dbContext.Quizzes.Add(quiz);
    }

    public async Task<IReadOnlyCollection<Domain.Quizzes.Quiz>> GetAllQuizzesAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Quizzes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Quizzes.Quiz?> GetAsync(Guid quizId, CancellationToken cancellationToken)
    {
        return await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == quizId, cancellationToken);
    }
}
