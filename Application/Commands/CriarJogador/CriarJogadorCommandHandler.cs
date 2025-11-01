using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.CriarJogador
{
    public class CriarJogadorCommandHandler : IRequestHandler<CriarJogadorCommand, Unit>
    {
        private readonly IJogadorRepository _JogadorRepository;
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public CriarJogadorCommandHandler(
            IJogadorRepository JogadorRepository,
            IPosicaoJogadorRepository posicaoJogadorRepository
        )
        {
            _JogadorRepository = JogadorRepository;
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            CriarJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            var existePosicao = await _posicaoJogadorRepository.PosicaoJogadorExisteAsync(
                request.InputModel.PosicaoJogadorId
            );

            if (!existePosicao)
            {
                throw new CustomException(
                    $"A posição {request.InputModel.PosicaoJogadorId} não existe. Não foi possível associá-la ao jogador {request.InputModel.Nome}.",
                    HttpStatusCode.BadRequest
                );
            }

            await _JogadorRepository.CriarJogadorAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
