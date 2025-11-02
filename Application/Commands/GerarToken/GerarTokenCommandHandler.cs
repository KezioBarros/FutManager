using System.Net;
using Application.Services;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.ViewModels;
using MediatR;
using Shared.Utils;

namespace Application.Commands.Autenticacao
{
    public class GerarTokenCommandHandler
        : IRequestHandler<GerarTokenCommand, AutenticacaoViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICryptoService _cryptoService;
        private readonly ITokenService _tokenService;

        public GerarTokenCommandHandler(
            IUsuarioRepository usuarioRepository,
            ICryptoService cryptoService,
            ITokenService tokenService
        )
        {
            _usuarioRepository = usuarioRepository;
            _cryptoService = cryptoService;
            _tokenService = tokenService;
        }

        public async Task<AutenticacaoViewModel> Handle(
            GerarTokenCommand request,
            CancellationToken cancellationToken
        )
        {
            var usuario = await _usuarioRepository.ObterUsuarioParaAutenticacaoAsync(
                request.Credenciais.Id
            );

            if (usuario == null)
            {
                throw new CustomException(
                    "Credenciais inválidas. Verifique e tente novamente.",
                    HttpStatusCode.BadRequest
                );
            }

            var senhaCorreta = _cryptoService.VerificarSenha(
                usuario.Senha,
                request.Credenciais.Senha
            );

            if (!senhaCorreta)
            {
                throw new CustomException(
                    "Credenciais inválidas. Verifique e tente novamente.",
                    HttpStatusCode.BadRequest
                );
            }

            var tokenClaims = new TokenClaimsViewModel(usuario.Id, usuario.TipoUsuarioId);

            var token = _tokenService.Gerar(tokenClaims);

            return new AutenticacaoViewModel(token, tokenClaims);
        }
    }
}
