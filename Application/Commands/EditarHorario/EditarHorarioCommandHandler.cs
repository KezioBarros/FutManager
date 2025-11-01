using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarHorario
{
    public class EditarHorarioCommandHandler : IRequestHandler<EditarHorarioCommand, Unit>
    {
        private readonly IHorarioRepository _horarioRepository;

        public EditarHorarioCommandHandler(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            EditarHorarioCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var horario in request.InputModel)
            {
                var horarioExiste = await _horarioRepository.HorarioExisteAsync(horario.Id);

                if (!horarioExiste)
                {
                    throw new CustomException(
                        $"Horário inexistente: {horario.Id}.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _horarioRepository.EditarHorarioAsync(horario);
            }

            return Unit.Value;
        }
    }
}
