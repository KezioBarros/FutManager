using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Queries.ListarHorarios
{
    public class ListarHorariosQuery : IRequest<List<HorarioViewModel?>>
    {
        public ListarHorariosQuery(HorarioFiltroInputModel inputModel, int pagina, int limite)
        {
            InputModel = inputModel;
            Pagina = pagina;
            Limite = limite;
        }

        public HorarioFiltroInputModel InputModel { get; set; }
        public int Pagina { get; set; }
        public int Limite { get; set; }
    }
}
