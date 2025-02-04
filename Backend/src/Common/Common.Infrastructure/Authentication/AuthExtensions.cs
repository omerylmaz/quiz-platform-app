using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Authentication;

internal static class AuthExtensions
{
    internal static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services.AddAuthentication().AddJwtBearer();

        services.AddAuthorization();

        services.AddHttpContextAccessor();

        services.ConfigureOptions<JwtBearerConfigureOptions>();

        return services;
    }
}
