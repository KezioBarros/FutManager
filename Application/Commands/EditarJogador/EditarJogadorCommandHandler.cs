using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.EditarJogador
{
    public class EditarJogadorCommandHandler : IRequestHandler<EditarJogadorCommand, Unit>
    {
        private readonly IJogadorRepository _JogadorRepository;

        public EditarJogadorCommandHandler(IJogadorRepository JogadorRepository)
        {
            _JogadorRepository = JogadorRepository;
        }

        public async Task<Unit> Handle(
            EditarJogadorCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var Jogador in request.InputModel)
            {
                await _JogadorRepository.EditarJogadorAsync(Jogador);
            }

            return Unit.Value;
        }
    }
}
