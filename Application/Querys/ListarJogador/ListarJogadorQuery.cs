using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarJogador
{
    public class ListarJogadorQuery : IRequest<List<JogadorViewModel?>>
    {
        public JogadorFiltroInputModel InputModel { get; set; }

        public int Pagina { get; set; }
        public int Limite { get; set; }

        public ListarJogadorQuery(JogadorFiltroInputModel inputModel, int pagina, int limite)
        {
            InputModel = inputModel;
            Pagina = pagina;
            Limite = limite;
        }
    }
}
