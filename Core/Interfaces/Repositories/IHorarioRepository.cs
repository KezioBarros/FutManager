using Core.Models.InputModels;

namespace Core.Interfaces.Repositories
{
    public interface IHorarioRepository
    {
        Task CriaNovoHorarioAsync(HorarioInputModel InputModel, DateTime Data);
    }
}
