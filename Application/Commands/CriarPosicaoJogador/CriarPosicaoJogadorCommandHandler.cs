using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CriarPosicaoJogador
{
    public class CriarPosicaoJogadorCommandHandler
        : IRequestHandler<CriarPosicaoJogadorCommand, Unit>
    {
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public CriarPosicaoJogadorCommandHandler(IPosicaoJogadorRepository posicaoJogadorRepository)
        {
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            CriarPosicaoJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            await _posicaoJogadorRepository.CriarPosicaoJogadorAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
