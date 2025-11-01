using Core.Models.InputModels;
using MediatR;

namespace Application.Commands
{
    public class CriaNovoHorarioCommand : IRequest<Unit>
    {
        public HorarioInputModel InputModel { get; set; }

        public CriaNovoHorarioCommand(HorarioInputModel inputModel)
        {
            InputModel = inputModel;
        }
    }
}
