using Core.Interfaces.Repositories;
using Core.Models.InputModels;
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
    }
}
