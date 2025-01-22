namespace Quiz.Domain.QuizSets;

public interface IQuizSetRepository
{
    void Add(QuizSet quizSet);
    Task<QuizSet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}
