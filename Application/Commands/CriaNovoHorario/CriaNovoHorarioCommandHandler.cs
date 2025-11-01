using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands
{
    public class CriaNovoHorarioCommandHandler : IRequestHandler<CriaNovoHorarioCommand, Unit>
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IUsuarioRepository _UsuarioRepository;

        public CriaNovoHorarioCommandHandler(
            IHorarioRepository horarioRepository,
            IUsuarioRepository usuarioRepository
        )
        {
            _horarioRepository = horarioRepository;
            _UsuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(
            CriaNovoHorarioCommand request,
            CancellationToken cancellationToken
        )
        {
            var UsuarioExiste = await _UsuarioRepository.UsuarioExisteAsync(
                request.InputModel.CriadoPorUsuarioId
            );

            if (!UsuarioExiste)
            {
                throw new CustomException(
                    $"O Usuario {request.InputModel.CriadoPorUsuarioId} não existe. Por favor, insira um Usuario válido.",
                    HttpStatusCode.BadRequest
                );
            }

            await _horarioRepository.CriaNovoHorarioAsync(request.InputModel, DateTime.Now);
            return Unit.Value;
        }
    }
}
