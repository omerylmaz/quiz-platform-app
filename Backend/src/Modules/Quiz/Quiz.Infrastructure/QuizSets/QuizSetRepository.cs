using Quiz.Domain.QuizSets;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.QuizSets;

internal sealed class QuizSetRepository(QuizDbContext dbContext) : IQuizSetRepository
{
    public void Add(QuizSet quizSet)
    {
        dbContext.QuizSets.Add(quizSet);
    }
}
