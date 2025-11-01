using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.EditarPosicaoJogador
{
    public class EditarPosicaoJogadorCommand : IRequest<Unit>
    {
        public List<EditarPosicaoJogadorInputModel> InputModel { get; set; }

        public EditarPosicaoJogadorCommand(List<EditarPosicaoJogadorInputModel> inputModel)
        {
            InputModel = inputModel;
        }
    }
}
