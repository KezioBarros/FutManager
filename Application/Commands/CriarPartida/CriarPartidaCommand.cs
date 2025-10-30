using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.CriarPartida
{
    public class CriarPartidaCommand : IRequest<Unit>
    {
        public PartidaInputModel inputModel { get; set; }

        public CriarPartidaCommand(PartidaInputModel inputModel)
        {
            this.inputModel = inputModel;
        }
    }
}
