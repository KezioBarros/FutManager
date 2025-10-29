using Core.Interfaces.Repositories;
using MediatR;

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
                await _horarioRepository.ExcluirHorarioAsync(id);
            }

            return Unit.Value;
        }
    }
}
