using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.EditarUsuario
{
    public class EditarUsuarioCommand : IRequest<Unit>
    {
        public List<EditarUsuarioInputModel> InputModel { get; set; }

        public EditarUsuarioCommand(List<EditarUsuarioInputModel> inputModel)
        {
            InputModel = inputModel;
        }
    }
}
