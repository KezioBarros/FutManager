using System.Net;
using Core.Interfaces.Repositories;
using MediatR;
using Shared.Utils;

namespace Application.Commands.ExcluirUsuario
{
    public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public ExcluirUsuarioCommandHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<Unit> Handle(
            ExcluirUsuarioCommand request,
            CancellationToken cancellationToken
        )
        {
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
