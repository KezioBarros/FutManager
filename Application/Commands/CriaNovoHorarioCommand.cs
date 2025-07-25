using Core.Models.InputModels;
using MediatR;

namespace Application.Commands
{
    public class CriaNovoHorarioCommand : IRequest<Unit>
    {
        public HorarioInputModel inputModel { get; set; }

        public CriaNovoHorarioCommand(HorarioInputModel inputModel)
        {
            this.inputModel = inputModel;
        }
    }
}
