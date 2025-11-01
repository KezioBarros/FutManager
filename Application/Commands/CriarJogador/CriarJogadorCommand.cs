using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.CriarJogador
{
    public class CriarJogadorCommand : IRequest<Unit>
    {
        public JogadorInputModel InputModel { get; set; }

        public CriarJogadorCommand(JogadorInputModel inputModel)
        {
            InputModel = inputModel;
        }
    }
}
