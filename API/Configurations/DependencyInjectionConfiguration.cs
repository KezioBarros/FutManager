using Application.Commands;
using Application.Services;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Repositories;

namespace API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContextConfiguration(configuration);

            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IPartidaRepository, PartidaRepository>();
            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IPosicaoJogadorRepository, PosicaoJogadorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddMediatR(option =>
                option.RegisterServicesFromAssembly(typeof(CriaNovoHorarioCommand).Assembly)
            );
        }
    }
}
