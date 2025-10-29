using MediatR;

namespace Application.Commands.ExcluirHorario
{
    public class ExcluirHorarioCommand : IRequest<Unit>
    {
        public List<int> HorarioIds { get; set; }

        public ExcluirHorarioCommand(List<int> horarioIds)
        {
            HorarioIds = horarioIds;
        }
    }
}
