using Core.Models.InputModels;

namespace Core.Interfaces.Repositories
{
    public interface IPartidaRepository
    {
        Task CriarPartidaAsync(PartidaInputModel inputModel);
    }
}
