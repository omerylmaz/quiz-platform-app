using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.API.Database;
using Quiz.API.Quizzes;

namespace Quiz.API;
public static class QuizModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateQuiz.MapEndpoint(app);
        GetQuiz.MapEndpoint(app);
    }

    public static IServiceCollection AddQuizModule(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<QuizDbContext>(options =>
        {
            options.UseNpgsql(
                databaseConnectionString,
                npgSqlOptions => npgSqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Constants.QuizzesSchema)
                )
            .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
