using System.Net;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarUsuario
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly ITokenService _tokenService;

        public EditarUsuarioCommandHandler(
            IUsuarioRepository UsuarioRepository,
            ITokenService tokenService
        )
        {
            _UsuarioRepository = UsuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(
            EditarUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var Usuario in request.InputModel)
            {
                if (Usuario.Id.ToString() != _tokenService.GetUsuarioId())
                {
                    if (_tokenService.GetTipoUsuarioId() != "1")
                    {
                        throw new CustomException(
                            $"Você não tem permissão para editar o usuário {Usuario.Id}.",
                            HttpStatusCode.Forbidden
                        );
                    }
                }

                var UsuarioExiste = await _UsuarioRepository.UsuarioExisteAsync(Usuario.Id);

                if (!UsuarioExiste)
                {
                    throw new CustomException(
                        $"O Usuario {Usuario.Nome} não existe. Por favor, insira um Usuario válido.",
                        HttpStatusCode.BadRequest
                    );
                }
                await _UsuarioRepository.EditarUsuarioAsync(Usuario);
            }

            return Unit.Value;
        }
    }
}
