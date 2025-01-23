namespace Quiz.Domain.QuizSets;

public interface IQuizSetRepository
{
    void Add(QuizSet quizSet);
    Task<QuizSet> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<QuizSet>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}
