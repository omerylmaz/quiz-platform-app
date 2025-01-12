using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Users.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
    
    public static IApplicationBuilder UseInfrastructureServices(this IApplicationBuilder app)
    {
        return app;
    }
}