using Quiz.Domain.Quizzes;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.Quizzes;

internal sealed class QuizRepository(QuizDbContext dbContext) : IQuizRepository
{
    public void Add(Domain.Quizzes.Quiz quiz)
    {
        dbContext.Quizzes.Add(quiz);
    }
}
