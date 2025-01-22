using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Questions;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.Questions;

public class QuestionRepository(QuizDbContext dbContext) : IQuestionRepository
{
    public void Add(Question question)
    {
        dbContext.Questions.Add(question);
    }

    public async void Delete(int id)
    {
        Question? question = await dbContext.Questions.FindAsync(id);
        if (question is null)
            return;

        dbContext.Questions.Remove(question);
    }

    public async Task<Question?> GetQuestionByIdAsync(Guid questionId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Questions
            .AsNoTracking()
            .Where(q => q.Id == questionId)
            .Include(q => q.Choices)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Question>> GetQuestionsByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Questions
            .AsNoTracking()
            .Where(q => q.QuizId == quizId)
            .Include(q => q.Choices)
            .ToListAsync(cancellationToken);
    }
}
