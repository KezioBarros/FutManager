using MediatR;

namespace Application.Commands.ExcluirJogador
{
    public class ExcluirJogadorCommand : IRequest<Unit>
    {
        public List<int> Ids { get; set; }

        public ExcluirJogadorCommand(List<int> ids)
        {
            Ids = ids;
        }
    }
}
