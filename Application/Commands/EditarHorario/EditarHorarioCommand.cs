using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.EditarHorario
{
    public class EditarHorarioCommand : IRequest<Unit>
    {
        public List<EditarHorarioInputModel> InputModel { get; set; }

        public EditarHorarioCommand(List<EditarHorarioInputModel> inputModel)
        {
            InputModel = inputModel;
        }
    }
}
