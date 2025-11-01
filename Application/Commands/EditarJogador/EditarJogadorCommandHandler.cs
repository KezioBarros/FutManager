using System.Net;
using System.Security.AccessControl;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarJogador
{
    public class EditarJogadorCommandHandler : IRequestHandler<EditarJogadorCommand, Unit>
    {
        private readonly IJogadorRepository _JogadorRepository;
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public EditarJogadorCommandHandler(
            IJogadorRepository JogadorRepository,
            IPosicaoJogadorRepository posicaoJogadorRepository
        )
        {
            _JogadorRepository = JogadorRepository;
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<Unit> Handle(
            EditarJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var Jogador in request.InputModel)
            {
                var jogadorExiste = await _JogadorRepository.JogadorExisteAsync(Jogador.Id);

                if (!jogadorExiste)
                {
                    throw new CustomException(
                        $"O jogador {Jogador.Nome} não existe. Por favor, insira um jogador válido.",
                        HttpStatusCode.BadRequest
                    );
                }

                var posicaoJogadorExiste =
                    await _posicaoJogadorRepository.PosicaoJogadorExisteAsync(
                        Jogador.PosicaoJogadorId
                    );

                if (!posicaoJogadorExiste)
                {
                    throw new CustomException(
                        $"A posição {Jogador.PosicaoJogadorId} não existe. Não foi possível associá-la ao jogador {Jogador.Nome}.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _JogadorRepository.EditarJogadorAsync(Jogador);
            }

            return Unit.Value;
        }
    }
}
