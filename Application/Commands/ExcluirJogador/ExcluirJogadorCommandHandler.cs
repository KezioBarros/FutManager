using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.ExcluirJogador
{
    public class ExcluirJogadorCommandHandler : IRequestHandler<ExcluirJogadorCommand, Unit>
    {
        private readonly IJogadorRepository _JogadorRepository;

        public ExcluirJogadorCommandHandler(IJogadorRepository JogadorRepository)
        {
            _JogadorRepository = JogadorRepository;
        }

        public async Task<Unit> Handle(
            ExcluirJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.Ids)
            {
                await _JogadorRepository.ExcluirJogadorAsync(id);
            }

            return Unit.Value;
        }
    }
}
