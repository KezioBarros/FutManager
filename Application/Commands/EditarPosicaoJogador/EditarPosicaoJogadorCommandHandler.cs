using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarPosicaoJogador
{
    public class EditarPosicaoJogadorCommandHandler
        : IRequestHandler<EditarPosicaoJogadorCommand, Unit>
    {
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public EditarPosicaoJogadorCommandHandler(
            IPosicaoJogadorRepository posicaoJogadorRepository
        )
        {
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            EditarPosicaoJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var posicaoJogador in request.InputModel)
            {
                var posicaoJogadorExiste =
                    await _posicaoJogadorRepository.PosicaoJogadorExisteAsync(posicaoJogador.Id);

                if (!posicaoJogadorExiste)
                {
                    throw new CustomException(
                        $"A posição informada (ID: {posicaoJogador.Id}) não existe.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _posicaoJogadorRepository.EditarPosicaoJogadorAsync(posicaoJogador);
            }

            return Unit.Value;
        }
    }
}
