using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommand : IRequest<Unit>
    {
        public UsuarioInputModel InputModel { get; set; }

        public CriarUsuarioCommand(UsuarioInputModel inputModel)
        {
            InputModel = inputModel;
        }
    }
}
