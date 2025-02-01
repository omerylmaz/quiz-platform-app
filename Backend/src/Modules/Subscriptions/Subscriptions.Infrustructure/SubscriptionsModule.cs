using Common.Infrastructure.Interceptors;
using Common.Presentation.Endpoints;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.CustomerSubscriptions;
using Subscriptions.Domain.Payments;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Infrustructure.Customers;
using Subscriptions.Infrustructure.CustomerSubscriptions;
using Subscriptions.Infrustructure.Database;
using Subscriptions.Infrustructure.Payments;
using Subscriptions.Infrustructure.SubscriptionBenefits;
using Subscriptions.Infrustructure.Subscriptions;
using Subscriptions.Presentation.Customers;

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
        services.AddScoped<ICustomerSubscriptionRepository, CustomerSubscriptionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SubscriptionsDbContext>());

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserRegisteredIntegrationEventConsumer>();
    }
}
