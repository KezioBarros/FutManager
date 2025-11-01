using System.ComponentModel.DataAnnotations;
using Application.Commands.CriarPartida;
using Application.Commands.EditarPartida;
using Application.Commands.ExcluirPartida;
using Application.Querys.ListarPartida;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Partida")]
    public class PartidaController : MainController
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

        /// <summary>
        /// Rota para listagem de partidas com suporte a paginação e filtros opcionais
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="pagina"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarPartidaAsync(
            [FromQuery] PartidaFiltroInputModel inputModel,
            [Required] int pagina,
            [Required] int limite
        )
        {
            var query = new ListarPartidaQuery(inputModel, pagina, limite);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Rota responsável por editar partida
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarPartidaAsync(
            List<EditarPartidaInputModel> inputModel
        )
        {
            var command = new EditarPartidaCommand(inputModel);

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Rota responsável por excluir partida
        /// </summary>
        /// <param name="inputModels"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExcluirPartidaAsync(
            List<ExcluirPartidaInputModel> inputModels
        )
        {
            var command = new ExcluirPartidaCommand(inputModels);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
