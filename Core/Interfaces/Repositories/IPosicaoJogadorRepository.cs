using Core.Models.InputModels;
using Core.Models.ViewModels;

namespace Core.Interfaces.Repositories
{
    public interface IPosicaoJogadorRepository
    {
        Task CriarPosicaoJogadorAsync(PosicaoJogadorInputModel inputModel);
        Task<List<PosicaoJogadorViewModel?>> ListarPosicaoJogadorAsync(
            PosicaoJogadorFiltroInputModel inputModel,
            int pagina,
            int limite
        );

        Task EditarPosicaoJogadorAsync(EditarPosicaoJogadorInputModel inputModel);
        Task ExcluirPosicaoJogadorAsync(int id);
    }
}
