using System.Net;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;
using Shared.Utils;

namespace Application.Commands.ExcluirUsuario
{
    public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly ITokenService _tokenService;

        public ExcluirUsuarioCommandHandler(
            IUsuarioRepository UsuarioRepository,
            ITokenService tokenService
        )
        {
            _UsuarioRepository = UsuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(
            ExcluirUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            var tipoUsuarioId = _tokenService.GetTipoUsuarioId();

            if (tipoUsuarioId != "1")
            {
                throw new CustomException(
                    "Você não tem permissão para excluir usuários.",
                    HttpStatusCode.Forbidden
                );
            }

            foreach (var id in request.Ids)
            {
                var UsuarioExiste = await _UsuarioRepository.UsuarioExisteAsync(id);

                if (!UsuarioExiste)
                {
                    throw new CustomException(
                        $"O Usuario {id} não existe. Por favor, insira um Usuario válido.",
                        HttpStatusCode.BadRequest
                    );
                }

                await _UsuarioRepository.ExcluirUsuarioAsync(id);
            }

            return Unit.Value;
        }
    }
}
