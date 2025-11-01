using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

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
                var jogadorExiste = await _JogadorRepository.JogadorExisteAsync(id);

                if (!jogadorExiste)
                {
                    throw new CustomException(
                        $"O jogador {id} não existe. Por favor, insira um jogador válido.",
                        HttpStatusCode.BadRequest
                    );
                }

                await _JogadorRepository.ExcluirJogadorAsync(id);
            }

            return Unit.Value;
        }
    }
}
