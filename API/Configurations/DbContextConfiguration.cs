using System.Net;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Utils;

namespace API.Configurations
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var environment = configuration["Environment"];

            string connectionString;
            switch (environment)
            {
                case "Development":
                    connectionString = configuration.GetConnectionString("ConnectionNpgsqlTest");
                    break;

                case "Production":
                    connectionString = configuration.GetConnectionString("ConnectionNpgsql");
                    break;

                default:
                    connectionString = null;
                    break;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new CustomException(
                    $"Conexão com o banco de dados não configurada corretamente para o ambiente: {environment}.",
                    HttpStatusCode.InternalServerError
                );
            }

            services.AddDbContext<FutManagerDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
