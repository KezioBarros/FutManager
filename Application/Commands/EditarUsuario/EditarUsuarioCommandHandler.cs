using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.EditarUsuario
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public EditarUsuarioCommandHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<Unit> Handle(
            EditarUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
            foreach (var Usuario in request.InputModel)
            {
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
