//using System.Data.Common;
//using Dapper;
//using Quiz.Application.Abstractions.Data;
//using Quiz.Application.Messaging;
//using Quiz.Domain.Abstractions;

//namespace Quiz.Application.Questions.GetQuestionByQuizId;

//internal sealed class GetQuestionByQuizIdQueryHandler(IDbConnectionFactory dbConnectionFactory)
//    : IQueryHandler<GetQuestionByQuizIdQuery, QuestionResponse>
//{
//    public async Task<Result<QuestionResponse>> Handle(GetQuestionByQuizIdQuery request, CancellationToken cancellationToken)
//    {
//        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

//        const string sqlQuestion =
//            $"""
//            SELECT 
//                q.id AS {nameof(QuestionResponse.Id)},
//                q.quiz_id AS {nameof(QuestionResponse.QuizId)},
//                q.text AS {nameof(QuestionResponse.Text)}
//            FROM Questions q
//            WHERE q.QuizId = @QuizId
//            """;

//        const string sqlChoices =
//            $"""
//            SELECT 
//                c.id AS {nameof(ChoiceResponse.Id)},
//                c.text AS {nameof(ChoiceResponse.Text)},
//                c.is_correct AS {nameof(ChoiceResponse.IsCorrect)}
//            FROM Choices c
//            WHERE c.question_id IN (
//                SELECT Id FROM Questions WHERE question_id = @QuestionId
//            )
//            """;

//        QuestionResponse? question = await connection.QuerySingleOrDefaultAsync<QuestionResponse>(
//            sqlQuestion,
//            new { request.QuizId }
//        );

//        if (question is null)
//            return null;

//        IEnumerable<ChoiceResponse> choices = await connection.QueryAsync<ChoiceResponse>(
//            sqlChoices,
//            new { QuestionId = question.Id }
//        );

//        return question with { Choices = choices.ToList().AsReadOnly() };
//    }
//}
