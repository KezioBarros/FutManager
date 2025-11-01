using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.CriarPartida
{
    public class CriarPartidaCommandHandler : IRequestHandler<CriarPartidaCommand, Unit>
    {
        private readonly IPartidaRepository _partidaRepository;
        private readonly IHorarioRepository _horarioRepository;

        public CriarPartidaCommandHandler(
            IPartidaRepository partidaRepository,
            IHorarioRepository horarioRepository
        )
        {
            _partidaRepository = partidaRepository;
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            CriarPartidaCommand request,
            CancellationToken cancellationToken
        )
        {
            var horarioExiste = await _horarioRepository.HorarioExisteAsync(
                request.InputModel.HorarioId
            );

            if (!horarioExiste)
            {
                throw new CustomException(
                    $"Horário {request.InputModel.HorarioId} não encontrado.",
                    HttpStatusCode.BadRequest
                );
            }

            await _partidaRepository.CriarPartidaAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
