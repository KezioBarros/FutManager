using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.ExcluirPartida
{
    public class ExcluirPartidaCommandHandler : IRequestHandler<ExcluirPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;
        private readonly IHorarioRepository _horarioRepository;

        public ExcluirPartidaCommandHandler(
            IPartidaRepository partidaRepository,
            IHorarioRepository horarioRepository
        )
        {
            _partidaRepository = partidaRepository;
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            ExcluirPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.InputModel)
            {
                var horarioExiste = await _horarioRepository.HorarioExisteAsync(id.HorarioId);

                if (!horarioExiste)
                {
                    throw new CustomException(
                        $"Horário {id.HorarioId} não encontrado.",
                        HttpStatusCode.BadRequest
                    );
                }

                var partidaExiste = await _partidaRepository.PartidaExisteAsync(
                    id.PartidaId,
                    id.HorarioId
                );

                if (!partidaExiste)
                {
                    throw new CustomException(
                        $"A partida {id.PartidaId} não foi encontrada no horário {id.HorarioId}.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _partidaRepository.ExcluirPartidaAsync(id.PartidaId, id.HorarioId);
            }

            return Unit.Value;
        }
    }
}
