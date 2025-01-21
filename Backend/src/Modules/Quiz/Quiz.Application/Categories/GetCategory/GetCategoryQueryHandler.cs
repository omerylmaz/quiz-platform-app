using System.Data.Common;
using Dapper;
using Quiz.Application.Abstractions.Data;
using Quiz.Application.Messaging;
using Quiz.Domain.Abstractions;
using Quiz.Domain.Categories;

namespace Quiz.Application.Categories.GetCategory;

internal sealed class GetCategoryQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetCategoryQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(CategoryResponse.Id)},
                 name AS {nameof(CategoryResponse.Name)}
             FROM quizzes.categories
             WHERE id = @CategoryId
             """;

        CategoryResponse? category = await connection.QueryFirstOrDefaultAsync<CategoryResponse>(sql, request);

        if (category is null)
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound(request.CategoryId));

        return category;
    }
}
