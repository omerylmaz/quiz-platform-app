using Common.Application.Data;
using Common.Infrastructure.Interceptors;
using Common.Presentation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Users;
using Users.Infrastructure.Database;
using Users.Infrastructure.Users;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Infrastructure;

public static class UsersModule
{
    public static IServiceCollection AddUsersModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddDbContext<UsersDbContext>((sp, options) =>
                    options
                        .UseNpgsql(
                            configuration.GetConnectionString("Database"),
                            npgsqlOptions => npgsqlOptions
                                .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Users))
                        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>())
                        .UseSnakeCaseNamingConvention());

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());

        return services;
    }
}
