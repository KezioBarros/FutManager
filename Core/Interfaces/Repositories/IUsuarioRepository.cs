using Core.Models.InputModels;
using Core.Models.ViewModels;

namespace Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task CriarUsuarioAsync(UsuarioInputModel inputModel);
        Task<List<UsuarioViewModel?>> ListarUsuarioAsync(
            UsuarioFiltroInputModel inputModel,
            int pagina,
            int limite
        );

        Task EditarUsuarioAsync(EditarUsuarioInputModel inputModel);
        Task ExcluirUsuarioAsync(int id);

        Task<bool> UsuarioExisteAsync(int id);
    }
}
