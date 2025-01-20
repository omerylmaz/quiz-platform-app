using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Quiz.Application.Abstractions.Data;
using Quiz.Domain.Quizzes;
using Quiz.Infrastructure.Data;
using Quiz.Infrastructure.Database;
using Quiz.Infrastructure.Quizzes;
using Quiz.Presentation.Quizzes;

namespace Quiz.Infrastructure;

public static class QuizModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        QuizEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddQuizModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

        string databaseConnectionString = configuration.GetConnectionString("Database");

        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(dataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddDbContext<QuizDbContext>(options =>
        {
            options.UseNpgsql(
                databaseConnectionString,
                npgSqlOptions => npgSqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Constants.QuizzesSchema)
                )
            .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IQuizRepository, QuizRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<QuizDbContext>());

        return services;
    }
}
