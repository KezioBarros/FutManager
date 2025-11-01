using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Querys.ListarUsuario
{
    public class ListarUsuarioQuery : IRequest<List<UsuarioViewModel?>>
    {
        public ListarUsuarioQuery(UsuarioFiltroInputModel inputModel, int pagina, int limite)
        {
            InputModel = inputModel;
            Pagina = pagina;
            Limite = limite;
        }

        public UsuarioFiltroInputModel InputModel { get; set; }

        public int Pagina { get; set; }
        public int Limite { get; set; }
    }
}
