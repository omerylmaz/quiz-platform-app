using Common.Application.Messaging;
using Common.Domain;
using Quiz.Application.QuizSets.GetQuizSet;
using Quiz.Domain.QuizSets;

namespace Quiz.Application.QuizSets.GetQuizSetsByUserId;

internal sealed class GetQuizSetsByUserIdQueryHandler(IQuizSetRepository quizSetRepository) : IQueryHandler<GetQuizSetsByUserIdQuery, IReadOnlyCollection<QuizSetResponse>>
{
    public async Task<Result<IReadOnlyCollection<QuizSetResponse>>> Handle(GetQuizSetsByUserIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<QuizSet> quizSets = await quizSetRepository.GetAllByUserIdAsync(request.UserId, cancellationToken);

        //List<string> categoryNames = quizSet.SelectMany(q => q.Categories).Select(c => c.Name).Distinct().ToList();

        var quizListResponse = quizSets.Select(q => new QuizSetResponse(q.Id, q.Title ?? string.Empty, q.Description ?? string.Empty, q.Categories.Select(c => c.Name).ToList())).ToList();

        //var quizSetResponse = new QuizSetResponse(quizSet.Id, quizSet.Title ?? string.Empty, quizSet.Description ?? string.Empty, categoryNames);

        return quizListResponse;
    }
}
