using System.Net;
using Application.Services;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;
using Shared.Utils;

namespace Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly ICryptoService _cryptoService;
        private readonly ITokenService _tokenService;

        public CriarUsuarioCommandHandler(
            IUsuarioRepository UsuarioRepository,
            ICryptoService cryptoService,
            ITokenService tokenService
        )
        {
            _UsuarioRepository = UsuarioRepository;
            _cryptoService = cryptoService;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(
            CriarUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.InputModel.TipoUsuarioId == 1)
            {
                if (_tokenService.GetTipoUsuarioId() != "1")
                {
                    throw new CustomException(
                        $"Você não tem permissão para inserir um usuário do tipo {request.InputModel.TipoUsuarioId}.",
                        HttpStatusCode.Forbidden
                    );
                }
            }

            request.InputModel.Senha = _cryptoService.HashPassword(request.InputModel.Senha);

            await _UsuarioRepository.CriarUsuarioAsync(request.InputModel);

            return Unit.Value;
        }
    }
}
