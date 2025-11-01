using Core.Interfaces.Repositories;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarUsuario
{
    public class ListarUsuarioQueryHandler
        : IRequestHandler<ListarUsuarioQuery, List<UsuarioViewModel?>>
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public ListarUsuarioQueryHandler(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<List<UsuarioViewModel?>> Handle(
            ListarUsuarioQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _UsuarioRepository.ListarUsuarioAsync(
                request.InputModel,
                request.Pagina,
                request.Limite
            );
        }
    }
}
