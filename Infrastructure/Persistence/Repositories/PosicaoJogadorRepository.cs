using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PosicaoJogadorRepository : IPosicaoJogadorRepository
    {
        private readonly FutebolDbContext _dbContext;

        public PosicaoJogadorRepository(FutebolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriarPosicaoJogadorAsync(PosicaoJogadorInputModel inputModel)
        {
            const string SQL =
                @"INSERT INTO posicao_jogador(descricao, pagamento_obrigatorio) VALUES ( @Descricao, @PagamentoObrigatorio);";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(SQL, new { inputModel.Descricao, inputModel.PagamentoObrigatorio });
        }

        public async Task<List<PosicaoJogadorViewModel?>> ListarPosicaoJogadorAsync(
            PosicaoJogadorFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            const string QUERY =
                @"SELECT 
                    id, 
                    descricao, 
                    pagamento_obrigatorio
                FROM 
                posicao_jogador
                WHERE 
                    (@Id IS NULL OR id = @Id)
                AND (@Descricao IS NULL OR descricao LIKE '%' || @Descricao || '%')
				AND (@PagamentoObrigatorio IS NULL OR pagamento_obrigatorio = @PagamentoObrigatorio)
                ORDER BY descricao, id
                LIMIT @limite
                OFFSET (@pagina - 1) * @limite;";

            return (
                await _dbContext
                    .Database.GetDbConnection()
                    .QueryAsync<PosicaoJogadorViewModel?>(
                        QUERY,
                        new
                        {
                            inputModel.Id,
                            inputModel.Descricao,
                            inputModel.PagamentoObrigatorio,
                            pagina,
                            limite,
                        }
                    )
            ).ToList();
        }

        public async Task EditarPosicaoJogadorAsync(EditarPosicaoJogadorInputModel inputModel)
        {
            const string SQL =
                @"UPDATE posicao_jogador SET  
                    descricao = @Descricao, pagamento_obrigatorio = @PagamentoObrigatorio
                 WHERE id = @Id;";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Id,
                        inputModel.Descricao,
                        inputModel.PagamentoObrigatorio,
                    }
                );
        }

        public async Task ExcluirPosicaoJogadorAsync(int id)
        {
            const string SQL = @"DELETE FROM posicao_jogador WHERE id = @id;";

            await _dbContext.Database.GetDbConnection().ExecuteAsync(SQL, new { id });
        }

        public async Task<bool> PosicaoJogadorExisteAsync(int id)
        {
            const string QUERY =
                @"SELECT EXISTS (SELECT 1 FROM posicao_jogador WHERE id = @id) AS existe;";

            return await _dbContext
                .Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<bool>(QUERY, new { id });
        }
    }
}
