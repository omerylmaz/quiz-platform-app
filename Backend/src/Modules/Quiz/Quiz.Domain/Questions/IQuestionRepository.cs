﻿using System.Linq.Expressions;

namespace Quiz.Domain.Questions;

public interface IQuestionRepository
{
    void Add(Question question);
    void Delete(int id);
    Task<Question?> GetQuestionByIdAsync(Guid questionId, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Question>> GetAllWhereAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Question>> GetAllByIdsAsync(List<Guid> QuestionIds, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Question>> GetQuestionsByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default);
}
