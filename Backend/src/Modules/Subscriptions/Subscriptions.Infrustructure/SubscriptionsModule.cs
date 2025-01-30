using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Common.Presentation.Endpoints;
using Subscriptions.Infrustructure.Database;
using Common.Infrastructure.Interceptors;
using Common.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Subscriptions.Infrustructure.Payments;
using Subscriptions.Domain.Payments;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Infrustructure.SubscriptionBenefits;
using Subscriptions.Infrustructure.Subscriptions;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Infrustructure.UserSubscriptions;
using Subscriptions.Domain.UserSubscriptions;

namespace Subscriptions.Infrustructure;

public static class SubscriptionsModule
{
    public static IServiceCollection AddSubscriptionsModule(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddDbContext<SubscriptionsDbContext>((sp, options) =>
                    options
                        .UseNpgsql(
                            configuration.GetConnectionString("Database"),
                            npgsqlOptions => npgsqlOptions
                                .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Subscriptions))
                        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>())
                        .UseSnakeCaseNamingConvention());

        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ISubscriptionBenefitRepository, SubscriptionBenefitRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SubscriptionsDbContext>());

        return services;
    }
}
