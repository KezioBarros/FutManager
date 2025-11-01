using Core.Interfaces.Repositories;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarPosicaoJogador
{
    public class ListarPosicaoJogadorQueryHandler
        : IRequestHandler<ListarPosicaoJogadorQuery, List<PosicaoJogadorViewModel?>>
    {
        private readonly IPosicaoJogadorRepository _posicaoJogadorRepository;

        public ListarPosicaoJogadorQueryHandler(IPosicaoJogadorRepository posicaoJogadorRepository)
        {
            _posicaoJogadorRepository = posicaoJogadorRepository;
        }

        public async Task<List<PosicaoJogadorViewModel?>> Handle(
            ListarPosicaoJogadorQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _posicaoJogadorRepository.ListarPosicaoJogadorAsync(
                request.InputModel,
                request.Pagina,
                request.Limite
            );
        }
    }
}
