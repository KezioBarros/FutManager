using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.EditarJogador
{
    public class EditarJogadorCommand : IRequest<Unit>
    {
        public List<EditarJogadorInputModel> InputModel { get; set; }

        public EditarJogadorCommand(List<EditarJogadorInputModel> inputModel)
        {
            InputModel = inputModel;
        }
    }
}
