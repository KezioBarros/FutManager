using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.EditarPartida
{
    public class EditarPartidaCommandHandler : IRequestHandler<EditarPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;

        public EditarPartidaCommandHandler(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<Unit> Handle(
            EditarPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var partida in request.InputModel)
            {
                await _partidaRepository.EditarPartidaAsync(partida);
            }

            return Unit.Value;
        }
    }
}
