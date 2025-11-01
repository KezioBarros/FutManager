using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.ExcluirPosicaoJogador
{
    public class ExcluirPosicaoJogadorCommandHandler
        : IRequestHandler<ExcluirPosicaoJogadorCommand, Unit>
    {
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public ExcluirPosicaoJogadorCommandHandler(
            IPosicaoJogadorRepository posicaoJogadorRepository
        )
        {
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            ExcluirPosicaoJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.Ids)
            {
                var posicaoJogadorExiste =
                    await _posicaoJogadorRepository.PosicaoJogadorExisteAsync(id);

                if (!posicaoJogadorExiste)
                {
                    throw new CustomException(
                        $"A posição informada (ID: {id}) não existe.",
                        HttpStatusCode.BadRequest
                    );
                }

                await _posicaoJogadorRepository.ExcluirPosicaoJogadorAsync(id);
            }

            return Unit.Value;
        }
    }
}
