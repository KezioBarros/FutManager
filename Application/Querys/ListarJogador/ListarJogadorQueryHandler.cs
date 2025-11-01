using Core.Interfaces.Repositories;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarJogador
{
    public class ListarJogadorQueryHandler
        : IRequestHandler<ListarJogadorQuery, List<JogadorViewModel?>>
    {
        private readonly IJogadorRepository _JogadorRepository;

        public ListarJogadorQueryHandler(IJogadorRepository JogadorRepository)
        {
            _JogadorRepository = JogadorRepository;
        }

        public async Task<List<JogadorViewModel?>> Handle(
            ListarJogadorQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _JogadorRepository.ListarJogadorAsync(
                request.InputModel,
                request.Pagina,
                request.Limite
            );
        }
    }
}
