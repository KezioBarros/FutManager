using Application.Services;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly ICryptoService _cryptoService;

        public CriarUsuarioCommandHandler(
            IUsuarioRepository UsuarioRepository,
            ICryptoService cryptoService
        )
        {
            _UsuarioRepository = UsuarioRepository;
            _cryptoService = cryptoService;
        }

        public async Task<Unit> Handle(
            CriarUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            request.InputModel.Senha = _cryptoService.HashPassword(request.InputModel.Senha);

            await _UsuarioRepository.CriarUsuarioAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
