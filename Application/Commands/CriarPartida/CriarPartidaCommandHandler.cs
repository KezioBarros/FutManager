using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CriarPartida
{
    public class CriarPartidaCommandHandler : IRequestHandler<CriarPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;

        public CriarPartidaCommandHandler(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<Unit> Handle(
            CriarPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            await _partidaRepository.CriarPartidaAsync(request.inputModel);

            return Unit.Value;
        }
    }
}
