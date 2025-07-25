using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class FutebolDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FutebolDbContext(
            IConfiguration configuration,
            DbContextOptions<FutebolDbContext> options
        )
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = _configuration["Environment"];
            var connectionString = string.Empty;

            if (environment == "Development")
            {
                connectionString = _configuration.GetConnectionString("ConnectionNpgsqlTest");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception(
                        "Conexão com o banco de dados do cliente não está configurada"
                    );
                }
            }
            else if (environment == "Production")
            {
                connectionString = _configuration.GetConnectionString("ConnectionNpgsql");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception(
                        "Conexão com o banco de dados do cliente não está configurada"
                    );
                }
            }
            else
            {
                throw new InvalidOperationException("Ambiente não configurado corretamente.");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
