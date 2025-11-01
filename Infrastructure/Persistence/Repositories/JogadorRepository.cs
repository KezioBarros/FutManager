using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly FutebolDbContext _dbContext;

        public JogadorRepository(FutebolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriarJogadorAsync(JogadorInputModel inputModel)
        {
            const string SQL =
                @"INSERT INTO jogador(nome, posicao_jogador_id) VALUES ( @Nome, @PosicaoJogadorId);";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(SQL, new { inputModel.Nome, inputModel.PosicaoJogadorId });
        }

        public async Task<List<JogadorViewModel?>> ListarJogadorAsync(
            JogadorFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            const string QUERY =
                @"SELECT 
                    id, 
                    nome, 
                    posicao_jogador_id
                FROM jogador
                WHERE 
                    (@Id IS NULL OR id = @Id)
                AND (@Nome IS NULL OR nome LIKE '%' || @Nome || '%')
				AND (@PosicaoJogadorId IS NULL OR posicao_jogador_id = @PosicaoJogadorId)
                ORDER BY nome, id
                LIMIT @limite
                OFFSET (@pagina - 1) * @limite;";

            return (
                await _dbContext
                    .Database.GetDbConnection()
                    .QueryAsync<JogadorViewModel?>(
                        QUERY,
                        new
                        {
                            inputModel.Id,
                            inputModel.Nome,
                            inputModel.PosicaoJogadorId,
                            pagina,
                            limite,
                        }
                    )
            ).ToList();
        }

        public async Task EditarJogadorAsync(EditarJogadorInputModel inputModel)
        {
            const string SQL =
                @"UPDATE jogador SET  nome = @Nome, posicao_jogador_id = @PosicaoJogadorId WHERE id = @Id;";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Id,
                        inputModel.Nome,
                        inputModel.PosicaoJogadorId,
                    }
                );
        }

        public async Task ExcluirJogadorAsync(int id)
        {
            const string SQL = @"DELETE FROM jogador WHERE id = @id;";

            await _dbContext.Database.GetDbConnection().ExecuteAsync(SQL, new { id });
        }

        public async Task<bool> JogadorExisteAsync(int id)
        {
            const string QUERY = @"SELECT EXISTS (SELECT 1 FROM jogador WHERE id = @id) AS existe;";

            return await _dbContext
                .Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<bool>(QUERY, new { id });
        }
    }
}
