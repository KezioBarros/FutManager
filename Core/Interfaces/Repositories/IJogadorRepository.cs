using Core.Models.InputModels;
using Core.Models.ViewModels;

namespace Core.Interfaces.Repositories
{
    public interface IJogadorRepository
    {
        Task CriarJogadorAsync(JogadorInputModel inputModel);
        Task<List<JogadorViewModel?>> ListarJogadorAsync(
            JogadorFiltroInputModel inputModel,
            int pagina,
            int limite
        );

        Task EditarJogadorAsync(EditarJogadorInputModel inputModel);
        Task ExcluirJogadorAsync(int id);

        Task<bool> JogadorExisteAsync(int id);
    }
}
