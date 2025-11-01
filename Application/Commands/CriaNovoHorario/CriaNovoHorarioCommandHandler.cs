using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CriaNovoHorarioCommandHandler : IRequestHandler<CriaNovoHorarioCommand, Unit>
    {
        private readonly IHorarioRepository _horarioRepository;

        public CriaNovoHorarioCommandHandler(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public async Task<Unit> Handle(
            CriaNovoHorarioCommand request,
            CancellationToken cancellationToken
        )
        {
            await _horarioRepository.CriaNovoHorarioAsync(request.InputModel, DateTime.Now);
            return Unit.Value;
        }
    }
}
