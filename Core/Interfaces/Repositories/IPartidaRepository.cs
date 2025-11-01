using Core.Models.InputModels;
using Core.Models.ViewModels;

namespace Core.Interfaces.Repositories
{
    public interface IPartidaRepository
    {
        Task CriarPartidaAsync(PartidaInputModel inputModel);

        Task<List<PartidaViewModel?>> ListarPartidaAsync(
            PartidaFiltroInputModel inputModel,
            int pagina,
            int limite
        );

        Task EditarPartidaAsync(EditarPartidaInputModel inputModel);
        Task ExcluirPartidaAsync(int id, int horarioId);
    }
}
