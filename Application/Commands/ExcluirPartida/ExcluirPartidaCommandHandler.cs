using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.ExcluirPartida
{
    public class ExcluirPartidaCommandHandler : IRequestHandler<ExcluirPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;

        public ExcluirPartidaCommandHandler(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<Unit> Handle(
            ExcluirPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.InputModel)
            {
                await _partidaRepository.ExcluirPartidaAsync(id.PartidaIds, id.HorarioIds);
            }

            return Unit.Value;
        }
    }
}
