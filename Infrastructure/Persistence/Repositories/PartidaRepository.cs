using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PartidaRepository : IPartidaRepository
    {
        private readonly FutebolDbContext _dbContext;

        public PartidaRepository(FutebolDbContext futebolDbContext)
        {
            _dbContext = futebolDbContext;
        }

        public async Task CriarPartidaAsync(PartidaInputModel inputModel)
        {
            const string SQL =
                @"INSERT INTO partida(
                    horario_id, tempo, quantidade_jogadores, data)
                    VALUES ( @HorarioId, @Tempo, @QuantidadeJogadores, @data);";

            await _dbContext
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

        public async Task<List<PartidaViewModel?>> ListarPartidaAsync(
            PartidaFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            const string QUERY =
                @"SELECT 
                    id, 
                    horario_id, 
                    tempo, 
                    quantidade_jogadores, 
                    data
                FROM partida
                WHERE 
                    (@Id IS NULL OR id = @Id)
                AND (@HorarioId IS NULL OR horario_id = @HorarioId)
                AND data >= COALESCE(@DataInicio, '1900-01-01'::date)
                AND data <= COALESCE(@DataFim, '3000-01-01'::date)
                ORDER BY horario_id, id
                LIMIT @limite
                OFFSET (@pagina - 1) * @limite;";

            return (
                await _dbContext
                    .Database.GetDbConnection()
                    .QueryAsync<PartidaViewModel?>(
                        QUERY,
                        new
                        {
                            inputModel.Id,
                            inputModel.HorarioId,
                            inputModel.DataInicio,
                            inputModel.DataFim,
                            pagina,
                            limite,
                        }
                    )
            ).ToList();
        }
    }
}
