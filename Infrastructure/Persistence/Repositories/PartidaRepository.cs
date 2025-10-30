using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PartidaRepository : IPartidaRepository
    {
        private readonly FutebolDbContext _futebolDbContext;

        public PartidaRepository(FutebolDbContext futebolDbContext)
        {
            _futebolDbContext = futebolDbContext;
        }

        public async Task CriarPartidaAsync(PartidaInputModel inputModel)
        {
            const string SQL =
                @"INSERT INTO partida(
                    horario_id, tempo, quantidade_jogadores, data)
                    VALUES ( @HorarioId, @Tempo, @QuantidadeJogadores, @data);";

            await _futebolDbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.HorarioId,
                        inputModel.Tempo,
                        inputModel.QuantidadeJogadores,
                        data = DateTime.Now,
                    }
                );
        }
    }
}
