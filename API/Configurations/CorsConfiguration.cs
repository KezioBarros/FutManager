namespace MDA.API.Configurations;

public static class CorsConfiguration
{
    public static void AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAnyOrigin",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }
            );

            options.AddPolicy(
                "AllowOnlyServe",
                policy =>
                {
                    policy.WithOrigins("https://0.0.0.0").AllowAnyHeader().AllowAnyMethod();
                }
            );
        });
    }
}
