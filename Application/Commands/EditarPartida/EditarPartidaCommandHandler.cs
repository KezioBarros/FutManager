using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarPartida
{
    public class EditarPartidaCommandHandler : IRequestHandler<EditarPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;
        private readonly IHorarioRepository _horarioRepository;

        public EditarPartidaCommandHandler(
            IPartidaRepository partidaRepository,
            IHorarioRepository horarioRepository
        )
        {
            _partidaRepository = partidaRepository;
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            EditarPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var partida in request.InputModel)
            {
                var horarioExiste = await _horarioRepository.HorarioExisteAsync(partida.HorarioId);

                if (!horarioExiste)
                {
                    throw new CustomException(
                        $"Horário {partida.HorarioId} não encontrado.",
                        HttpStatusCode.BadRequest
                    );
                }

                var partidaExiste = await _partidaRepository.PartidaExisteAsync(
                    partida.Id,
                    partida.HorarioId
                );

                if (!partidaExiste)
                {
                    throw new CustomException(
                        $"A partida {partida.Id} não foi encontrada no horário {partida.HorarioId}.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _partidaRepository.EditarPartidaAsync(partida);
            }

            return Unit.Value;
        }
    }
}
