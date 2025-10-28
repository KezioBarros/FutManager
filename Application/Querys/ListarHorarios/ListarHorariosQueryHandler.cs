using Application.Queries.ListarHorarios;
using Core.Interfaces.Repositories;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarHorarios
{
    public class ListarHorariosQueryHandler
        : IRequestHandler<ListarHorariosQuery, List<HorarioViewModel?>>
    {
        private readonly IHorarioRepository _horarioRepository;

        public ListarHorariosQueryHandler(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public Task<List<HorarioViewModel?>> Handle(
            ListarHorariosQuery request,
            CancellationToken cancellationToken
        )
        {
            return _horarioRepository.ListarHorariosAsync(
                request.InputModel,
                request.Pagina,
                request.Limite
            );
        }
    }
}
