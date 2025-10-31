using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.CriarPartida
{
    public class CriarPartidaCommand : IRequest<Unit>
    {
        public PartidaInputModel InputModel { get; set; }

        public CriarPartidaCommand(PartidaInputModel inputModel)
        {
            InputModel = inputModel;
        }
    }
}
