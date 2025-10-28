using Core.Models.InputModels;
using Core.Models.ViewModels;

namespace Core.Interfaces.Repositories
{
    public interface IHorarioRepository
    {
        Task CriaNovoHorarioAsync(HorarioInputModel InputModel, DateTime Data);
        Task<List<HorarioViewModel?>> ListarHorariosAsync(
            HorarioFiltroInputModel inputModel,
            int pagina,
            int limite
        );
    }
}
