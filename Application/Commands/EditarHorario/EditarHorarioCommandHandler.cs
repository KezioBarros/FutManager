using Core.Interfaces.Repositories;
using MediatR;

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
                await _horarioRepository.EditarHorarioAsync(horario);
            }

            return Unit.Value;
        }
    }
}
