using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application;
using Quiz.Application.Abstractions.Data;
using Quiz.Domain.Categories;
using Quiz.Domain.Questions;
using Quiz.Domain.QuizSets;
using Quiz.Domain.Quizzes;
using Quiz.Infrastructure.Categories;
using Quiz.Infrastructure.Database;
using Quiz.Infrastructure.Questions;
using Quiz.Infrastructure.QuizSets;
using Quiz.Infrastructure.Quizzes;
using Quiz.Presentation.Categories;
using Quiz.Presentation.QuizSets;
using Quiz.Presentation.Quizzes;

namespace Quiz.Infrastructure;

public static class QuizModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        QuizEndpoints.MapEndpoints(app);
        CategoryEndpoints.MapEndpoints(app);
        QuizSetEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddQuizModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();

        string databaseConnectionString = configuration.GetConnectionString("Database");


        services.AddDbContext<QuizDbContext>(options =>
        {
            options.UseNpgsql(
                databaseConnectionString,
                npgSqlOptions => npgSqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Constants.QuizzesSchema)
                )
            .UseSnakeCaseNamingConvention()
            .AddInterceptors();
        });

        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IQuizSetRepository, QuizSetRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<QuizDbContext>());

        return services;
    }
}
