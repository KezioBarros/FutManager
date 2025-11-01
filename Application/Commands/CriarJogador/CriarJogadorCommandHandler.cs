using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CriarJogador
{
    public class CriarJogadorCommandHandler : IRequestHandler<CriarJogadorCommand, Unit>
    {
        private readonly IJogadorRepository _JogadorRepository;

        public CriarJogadorCommandHandler(IJogadorRepository JogadorRepository)
        {
            _JogadorRepository = JogadorRepository;
        }

        public async Task<Unit> Handle(
            CriarJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            await _JogadorRepository.CriarJogadorAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
