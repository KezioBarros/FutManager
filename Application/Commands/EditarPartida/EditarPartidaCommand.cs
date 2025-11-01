using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.EditarPartida
{
    public class EditarPartidaCommand : IRequest<Unit>
    {
        public List<EditarPartidaInputModel> InputModel { get; set; }

        public EditarPartidaCommand(List<EditarPartidaInputModel> inputModel)
        {
            InputModel = inputModel;
        }
    }
}
