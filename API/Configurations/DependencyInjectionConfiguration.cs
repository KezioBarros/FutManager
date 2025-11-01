using Application.Commands;
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
            services.AddScoped<IPosicaoJogadorRepository, PosicaoJogadorRepository>();

            services.AddMediatR(option =>
                option.RegisterServicesFromAssembly(typeof(CriaNovoHorarioCommand).Assembly)
            );
        }
    }
}
