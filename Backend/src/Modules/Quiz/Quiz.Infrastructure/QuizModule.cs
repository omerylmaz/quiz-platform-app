using Common.Infrastructure.Interceptors;
using Common.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

namespace Quiz.Infrastructure;

public static class QuizModule
{
    public static IServiceCollection AddQuizModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        string databaseConnectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<QuizDbContext>((sp, options) =>
        {
            options.UseNpgsql(
                databaseConnectionString,
                npgSqlOptions => npgSqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Constants.QuizzesSchema)
                )
            .UseSnakeCaseNamingConvention()
            .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });

        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IQuizSetRepository, QuizSetRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<QuizDbContext>());

        return services;
    }
}
