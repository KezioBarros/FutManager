using Application.Commands;
using Application.Services;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

namespace API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<FutebolDbContext>();

            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IPartidaRepository, PartidaRepository>();
            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IPosicaoJogadorRepository, PosicaoJogadorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICryptoService, CryptoService>();

            services.AddMediatR(option =>
                option.RegisterServicesFromAssembly(typeof(CriaNovoHorarioCommand).Assembly)
            );
        }
    }
}
