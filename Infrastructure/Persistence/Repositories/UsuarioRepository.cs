using Core.Interfaces.Repositories;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FutManagerDbContext _dbContext;

        public UsuarioRepository(FutManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriarUsuarioAsync(UsuarioInputModel inputModel)
        {
            const string SQL =
                @"INSERT INTO usuario(nome, email, senha, tipo_usuario_id) VALUES ( @Nome, @Email, @Senha, @TipoUsuarioId);";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Nome,
                        inputModel.Email,
                        inputModel.Senha,
                        inputModel.TipoUsuarioId,
                    }
                );
        }

        public async Task<List<UsuarioViewModel?>> ListarUsuarioAsync(
            UsuarioFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            const string QUERY =
                @"SELECT 
                    id, 
                    nome, 
                    email, 
                    tipo_usuario_id
	            FROM usuario
                WHERE 
                    (@Id IS NULL OR id = @Id)
                AND (@Nome IS NULL OR nome LIKE '%' || @Nome || '%')
				AND (@Email IS NULL OR email LIKE '%' || @Email || '%')
				AND (@TipoUsuarioId IS NULL OR tipo_usuario_id = @TipoUsuarioId)
                ORDER BY nome, id
                LIMIT @limite
                OFFSET (@pagina - 1) * @limite;";

            return (
                await _dbContext
                    .Database.GetDbConnection()
                    .QueryAsync<UsuarioViewModel?>(
                        QUERY,
                        new
                        {
                            inputModel.Id,
                            inputModel.Nome,
                            inputModel.Email,
                            inputModel.TipoUsuarioId,
                            pagina,
                            limite,
                        }
                    )
            ).ToList();
        }

        public async Task EditarUsuarioAsync(EditarUsuarioInputModel inputModel)
        {
            const string SQL = @"UPDATE usuario SET  nome = @Nome, email = @Email WHERE id = @Id;";

            await _dbContext
                .Database.GetDbConnection()
                .ExecuteAsync(
                    SQL,
                    new
                    {
                        inputModel.Id,
                        inputModel.Nome,
                        inputModel.Email,
                    }
                );
        }

        public async Task ExcluirUsuarioAsync(int id)
        {
            const string SQL = @"DELETE FROM Usuario WHERE id = @id;";

            await _dbContext.Database.GetDbConnection().ExecuteAsync(SQL, new { id });
        }

        public async Task<bool> UsuarioExisteAsync(int id)
        {
            const string QUERY = @"SELECT EXISTS (SELECT 1 FROM Usuario WHERE id = @id) AS existe;";

            return await _dbContext
                .Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<bool>(QUERY, new { id });
        }

        public async Task<UsuarioAutenticacaoViewModel?> ObterUsuarioParaAutenticacaoAsync(int id)
        {
            const string QUERY =
                @"SELECT 
                id AS Id,
                senha AS ""Senha"", 
                tipo_usuario_id AS ""TipoUsuarioId""
                FROM usuario WHERE id = @id";

            return await _dbContext
                .Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<UsuarioAutenticacaoViewModel?>(QUERY, new { id });
        }
    }
}
