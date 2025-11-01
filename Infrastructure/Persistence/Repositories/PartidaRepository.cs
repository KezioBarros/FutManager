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

        public PartidaRepository(FutebolDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task EditarPartidaAsync(EditarPartidaInputModel inputModel)
        {
            const string SQL =
                @"UPDATE partida SET tempo = @Tempo, quantidade_jogadores = @QuantidadeJogadores 
                WHERE id = @Id AND horario_id = @HorarioId;";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Id,
                        inputModel.HorarioId,
                        inputModel.Tempo,
                        inputModel.QuantidadeJogadores,
                    }
                );
        }

        public async Task ExcluirPartidaAsync(int id, int horarioId)
        {
            const string SQL = @"DELETE FROM partida WHERE id = @id AND horario_id = @horarioId;";

            await _dbContext.Database.GetDbConnection().ExecuteAsync(SQL, new { id, horarioId });
        }
    }
}
