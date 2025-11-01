using MediatR;

namespace Application.Commands.ExcluirPosicaoJogador
{
    public class ExcluirPosicaoJogadorCommand : IRequest<Unit>
    {
        public List<int> Ids { get; set; }

        public ExcluirPosicaoJogadorCommand(List<int> ids)
        {
            Ids = ids;
        }
    }
}
