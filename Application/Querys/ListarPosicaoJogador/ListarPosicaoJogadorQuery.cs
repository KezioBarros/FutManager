using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarPosicaoJogador
{
    public class ListarPosicaoJogadorQuery : IRequest<List<PosicaoJogadorViewModel?>>
    {
        public PosicaoJogadorFiltroInputModel InputModel { get; set; }

        public int Pagina { get; set; }
        public int Limite { get; set; }

        public ListarPosicaoJogadorQuery(
            PosicaoJogadorFiltroInputModel inputModel,
            int pagina,
            int limite
        )
        {
            InputModel = inputModel;
            Pagina = pagina;
            Limite = limite;
        }
    }
}
