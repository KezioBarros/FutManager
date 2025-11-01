using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public CriarUsuarioCommandHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<Unit> Handle(
            CriarUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            await _UsuarioRepository.CriarUsuarioAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
