using Common.Application.Caching;
using Common.Application.EventBus;
using Common.Infrastructure.Caching;
using Common.Infrastructure.Interceptors;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

namespace Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string redisConnectionString)
    {
        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(redisConnectionString));

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(config =>
        {
            foreach (Action<IRegistrationConfigurator> configureConsumer in moduleConfigureConsumers)
            {
                configureConsumer(config);
            }

            config.SetKebabCaseEndpointNameFormatter();

            config.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
