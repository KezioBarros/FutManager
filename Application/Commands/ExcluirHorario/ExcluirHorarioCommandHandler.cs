using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.ExcluirHorario
{
    public class ExcluirHorarioCommandHandler : IRequestHandler<ExcluirHorarioCommand, Unit>
    {
        private readonly IHorarioRepository _horarioRepository;

        public ExcluirHorarioCommandHandler(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            ExcluirHorarioCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var id in request.HorarioIds)
            {
                var horarioExiste = await _horarioRepository.HorarioExisteAsync(id);

                if (!horarioExiste)
                {
                    throw new CustomException(
                        $"Horário inexistente: {id}.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _horarioRepository.ExcluirHorarioAsync(id);
            }

            return Unit.Value;
        }
    }
}
