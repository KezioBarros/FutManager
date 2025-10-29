using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly FutebolDbContext _dbContext;

        public HorarioRepository(FutebolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaNovoHorarioAsync(HorarioInputModel InputModel, DateTime Data)
        {
            const string SQL =
                @"INSERT INTO horario(
                    criado_por_usuario_id, valor, horas_contratadas, data)
                    VALUES (@CriadoPorUsuarioId, @Valor, @HorasContratadas, @Data);";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        InputModel.CriadoPorUsuarioId,
                        InputModel.Valor,
                        InputModel.HorasContratadas,
                        Data,
                    }
                );
        }

        public async Task<List<HorarioViewModel?>> ListarHorariosAsync(
            HorarioFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            const string QUERY =
                @"SELECT 
                    id, 
                    criado_por_usuario_id, 
                    valor, 
                    horas_contratadas, 
                    data
                FROM 
                    horario
                WHERE 
                    (@Id IS NULL OR id = @Id)
                    AND (@CriadoPorUsuarioId IS NULL OR criado_por_usuario_id = @CriadoPorUsuarioId)
                    AND (@Valor IS NULL OR valor = @Valor)
                    AND (@HorasContratadas IS NULL OR horas_contratadas = @HorasContratadas)

                    AND data >= COALESCE(@DataInicio, '1900-01-01'::date)
                    AND data <= COALESCE(@DataFim, '3000-01-01'::date)
                ORDER BY 
                    id
                LIMIT @limite
                OFFSET (@pagina - 1) * @limite;";

            return (
                await _dbContext
                    .Database.GetDbConnection()
                    .QueryAsync<HorarioViewModel?>(
                        QUERY,
                        new
                        {
                            inputModel.Id,
                            inputModel.CriadoPorUsuarioId,
                            inputModel.Valor,
                            inputModel.HorasContratadas,
                            inputModel.DataInicio,
                            inputModel.DataFim,
                            pagina,
                            limite,
                        }
                    )
            ).ToList();
        }

        public async Task EditarHorarioAsync(EditarHorarioInputModel inputModel)
        {
            const string SQL =
                @"UPDATE horario SET valor = @Valor, horas_contratadas = @Horas_contratadas WHERE id = @Id;";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Id,
                        inputModel.Horas_contratadas,
                        inputModel.Valor,
                    }
                );
        }

        public async Task ExcluirHorarioAsync(int id)
        {
            const string SQL = @"DELETE FROM horario WHERE id = @id;";

            await _dbContext.Database.GetDbConnection().ExecuteAsync(SQL, new { id });
        }
    }
}
