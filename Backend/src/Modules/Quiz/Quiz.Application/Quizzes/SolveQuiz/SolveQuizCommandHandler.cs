using Common.Application.Messaging;
using Common.Domain;
using Quiz.Domain.Questions;
using Quiz.Domain.Quizzes;

namespace Quiz.Application.Quizzes.SolveQuiz;

internal sealed class SolveQuizCommandHandler(
    IQuizRepository quizRepository,
    IQuestionRepository questionRepository) : ICommandHandler<SolveQuizCommand, SolveQuizResponse>
{
    public async Task<Result<SolveQuizResponse>> Handle(SolveQuizCommand request, CancellationToken cancellationToken)
    {
        Domain.Quizzes.Quiz? quiz = await quizRepository.GetAsync(request.QuizId, cancellationToken);
        if (quiz is null)
            return Result.Failure<SolveQuizResponse>(QuizErrors.NotFound(request.QuizId));

        List<Guid> questionIds = request.Questions.Select(q => q.QuestionId).ToList();
        IReadOnlyCollection<Question> questions = await questionRepository.GetAllWhereAsync(q => questionIds.Contains(q.Id), cancellationToken);

        int correctCount = 0;

        foreach (SolveQuizQuestion solveQuestion in request.Questions)
        {
            Question? question = questions.FirstOrDefault(q => q.Id == solveQuestion.QuestionId);

            if (question is null)
                continue;

            if (question.Choices.Any(q => q.Id == solveQuestion.ChoiceId && q.IsCorrect))
            {
                correctCount++;
            }
        }

        int result = correctCount / request.Questions.Count * 100;
        var response = new SolveQuizResponse(result);
        return Result.Success(response);
    }
}
