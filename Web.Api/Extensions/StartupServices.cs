using Web.Api.Configuration;

namespace Web.Api.Extensions;

internal static class StartupServices
{
    public static void AddDefaultCors(this IServiceCollection services, IConfiguration configuration)
    {
        var cors = configuration
            .GetSection(Cors.Position)
            .Get<Cors>();

        if (cors is null or { Origins.Length: 0 })
        {
            throw new NullReferenceException("Cors configuration not found or not correct.");
        }

        services.AddCors(setup => setup
            .AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(cors.Origins);
            })
        );
    }
}
