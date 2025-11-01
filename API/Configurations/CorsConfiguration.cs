namespace API.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var allowedOrigins = configuration
                .GetSection("CorsSettings:AllowedOrigins")
                .Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowConfiguredOrigins",
                    policy =>
                    {
                        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });
        }
    }
}
