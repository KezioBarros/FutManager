using Application.Commands;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/horario")]
    public class HorarioController : MainController
    {
        private readonly IMediator _mediator;

        public HorarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rota responsável por criar um horário que conterá as partidas
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriaNovoHorarioAsync(HorarioInputModel inputModel)
        {
            var command = new CriaNovoHorarioCommand(inputModel);
            var horario = await _mediator.Send(command);

            return Ok(horario);
        }
    }
}
