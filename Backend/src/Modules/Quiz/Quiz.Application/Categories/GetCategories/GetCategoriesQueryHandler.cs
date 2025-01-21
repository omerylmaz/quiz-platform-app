using System.Data.Common;
using Dapper;
using Quiz.Application.Abstractions.Data;
using Quiz.Application.Categories.GetCategory;
using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;

namespace Quiz.Application.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(CategoryResponse.Id)},
                 name AS {nameof(CategoryResponse.Name)}
             FROM quizzes.categories
             """;

        List<CategoryResponse> categories = (await connection.QueryAsync<CategoryResponse>(sql, request)).AsList();

        return categories;
    }
}
