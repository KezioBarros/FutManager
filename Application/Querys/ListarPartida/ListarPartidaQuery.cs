using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarPartida
{
    public class ListarPartidaQuery : IRequest<List<PartidaViewModel?>>
    {
        public PartidaFiltroInputModel InputModel { get; set; }

        public int Pagina { get; set; }
        public int Limite { get; set; }

        public ListarPartidaQuery(PartidaFiltroInputModel inputModel, int pagina, int limite)
        {
            InputModel = inputModel;
            Pagina = pagina;
            Limite = limite;
        }
    }
}
