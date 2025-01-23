using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;
using Quiz.Domain.QuizSets;

namespace Quiz.Application.QuizSets.GetQuizSet;

internal sealed class GetQuizSetQueryHandler(IQuizSetRepository quizSetRepository) : IQueryHandler<GetQuizSetQuery, QuizSetResponse>
{
    public async Task<Result<QuizSetResponse>> Handle(GetQuizSetQuery request, CancellationToken cancellationToken)
    {
        QuizSet quizSet = await quizSetRepository.GetAsync(request.Id, cancellationToken);

        List<string> categoryNames = quizSet.Categories.Select(c => c.Name).ToList();

        QuizSetResponse response = new QuizSetResponse(quizSet.Id, quizSet.Title ?? string.Empty, quizSet.Description ?? string.Empty, categoryNames);

        return response;
    }
}
