using Core.Interfaces.Repositories;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarPartida
{
    public class ListarPartidaQueryHandler
        : IRequestHandler<ListarPartidaQuery, List<PartidaViewModel?>>
    {
        private readonly IPartidaRepository _partidaRepository;

        public ListarPartidaQueryHandler(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<List<PartidaViewModel?>> Handle(
            ListarPartidaQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _partidaRepository.ListarPartidaAsync(
                request.InputModel,
                request.Pagina,
                request.Limite
            );
        }
    }
}
