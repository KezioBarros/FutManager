using Core.Models.InputModels;
using MediatR;

namespace Application.Commands.ExcluirPartida
{
    public class ExcluirPartidaCommand : IRequest<Unit>
    {
        public ExcluirPartidaCommand(List<ExcluirPartidaInputModel> inputModel)
        {
            InputModel = inputModel;
        }

        public List<ExcluirPartidaInputModel> InputModel { get; set; }
    }
}
