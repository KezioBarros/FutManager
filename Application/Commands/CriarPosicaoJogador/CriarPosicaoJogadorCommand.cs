using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.CriarPosicaoJogador
{
    public class CriarPosicaoJogadorCommand : IRequest<Unit>
    {
        public PosicaoJogadorInputModel InputModel { get; set; }

        public CriarPosicaoJogadorCommand(PosicaoJogadorInputModel inputModel)
        {
            InputModel = inputModel;
        }
    }
}
