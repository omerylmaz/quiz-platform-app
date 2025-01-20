using System.Data.Common;
using Dapper;
using MediatR;
using Quiz.Application.Abstractions.Data;

namespace Quiz.Application.Quizzes.GetQuiz;

internal sealed class GetQuizQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IRequestHandler<GetQuizQuery, QuizResponse?>
{
    public async Task<QuizResponse?> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
            Select
            id as {nameof(QuizResponse.Id)}
            quiz_set_id as {nameof(QuizResponse.QuizSetId)}
            title as {nameof(QuizResponse.Title)}
            description as {nameof(QuizResponse.Description)}
            created_by_ai as {nameof(QuizResponse.CreatedByAI)}
            difficulty as {nameof(QuizResponse.Difficulty)}
            """;

        QuizResponse? quiz = await connection.QuerySingleOrDefaultAsync(sql, request);
        return quiz;
    }
}
