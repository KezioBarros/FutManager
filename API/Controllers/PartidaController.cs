using Application.Commands.CriarPartida;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Partida")]
    public class PartidaController : Controller
    {
        private readonly IMediator _mediator;

        public PartidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rota responsável por criar uma partida dentro de um horário.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarPartidaAsync([FromBody] PartidaInputModel inputModel)
        {
            var commands = new CriarPartidaCommand(inputModel);

            await _mediator.Send(commands);

            return Ok();
        }
    }
}
