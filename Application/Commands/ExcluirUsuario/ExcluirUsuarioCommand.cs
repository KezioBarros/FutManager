using MediatR;

namespace Application.Commands.ExcluirUsuario
{
    public class ExcluirUsuarioCommand : IRequest<Unit>
    {
        public List<int> Ids { get; set; }

        public ExcluirUsuarioCommand(List<int> ids)
        {
            Ids = ids;
        }
    }
}
