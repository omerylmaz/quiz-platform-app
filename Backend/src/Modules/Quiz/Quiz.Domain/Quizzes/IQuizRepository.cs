namespace Quiz.Domain.Quizzes;

public interface IQuizRepository
{
    Task<IReadOnlyCollection<Quiz>> GetAllQuizzesAsync(CancellationToken cancellationToken);

    Task<Quiz?> GetAsync(Guid quizId, CancellationToken cancellationToken);

    void Add(Quiz quiz);
}
