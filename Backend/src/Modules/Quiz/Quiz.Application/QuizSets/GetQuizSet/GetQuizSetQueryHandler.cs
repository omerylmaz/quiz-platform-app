using Quiz.Application.Categories.GetCategory;
using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;
using Quiz.Domain.Categories;
using Quiz.Domain.QuizSets;

namespace Quiz.Application.QuizSets.GetQuizSet;

internal class GetQuizSetQueryHandler(IQuizSetRepository quizSetRepository) : IQueryHandler<GetQuizSetQuery, QuizSetResponse>
{
    public async Task<Result<QuizSetResponse>> Handle(GetQuizSetQuery request, CancellationToken cancellationToken)
    {
        QuizSet quizSet = await quizSetRepository.GetByUserIdAsync(request.UserId, cancellationToken);

        if (quizSet is null)
        {
            return Result.Failure<QuizSetResponse>(QuizSetErrors.NotFoundByUserId(request.UserId));
        }

        List<string> categoryNames = quizSet.Categories.Select(q => q.Name).ToList();

        var quizSetResponse = new QuizSetResponse(quizSet.Id, quizSet.Title ?? string.Empty, quizSet.Description ?? string.Empty, categoryNames);

        return quizSetResponse;
    }
}
