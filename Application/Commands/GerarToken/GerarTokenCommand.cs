using Core.Models.InputModels;
using Core.Models.ViewModels;
using MediatR;

namespace Application.Commands.Autenticacao
{
    public class GerarTokenCommand : IRequest<AutenticacaoViewModel>
    {
        public UsuarioAutenticacaoInputModel Credenciais { get; set; }

        public GerarTokenCommand(UsuarioAutenticacaoInputModel credenciais)
        {
            Credenciais = credenciais;
        }
    }
}
