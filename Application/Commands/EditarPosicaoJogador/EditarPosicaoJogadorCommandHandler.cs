using Core.Interfaces.Repositories;
using MediatR;

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
                await _posicaoJogadorRepository.EditarPosicaoJogadorAsync(posicaoJogador);
            }

            return Unit.Value;
        }
    }
}
