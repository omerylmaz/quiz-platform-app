﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Questions;
using Quiz.Infrastructure.Database;

namespace Quiz.Infrastructure.Questions;

internal sealed class QuestionRepository(QuizDbContext dbContext) : IQuestionRepository
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

    public async Task<IReadOnlyCollection<Question>> GetAllByIdsAsync(List<Guid> QuestionIds, CancellationToken cancellationToken = default)
    {
        return await dbContext.Questions
            .Where(q => QuestionIds.Contains(q.Id))
            .Include(q => q.Choices)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Question>> GetAllWhereAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Questions
            .Where(predicate)
            .ToListAsync(cancellationToken);
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
