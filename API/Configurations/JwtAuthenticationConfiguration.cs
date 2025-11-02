using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Utils;

namespace API.Configurations
{
    public static class JwtAuthenticationConfiguration
    {
        public static IServiceCollection AddJwtAuthenticationConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey");

            if (string.IsNullOrWhiteSpace(secretKey))
                throw new CustomException(
                    "A chave 'SecretKey' está ausente no appsettings.json",
                    HttpStatusCode.BadRequest
                );

            var keyBytes = Encoding.UTF8.GetBytes(secretKey);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            return services;
        }
    }
}
