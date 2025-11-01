using System.ComponentModel.DataAnnotations;
using Application.Commands.CriarJogador;
using Application.Commands.EditarJogador;
using Application.Commands.ExcluirJogador;
using Application.Querys.ListarJogador;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Jogador")]
    public class JogadorController : MainController
    {
        private readonly IMediator _mediator;

        public JogadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rota responsável por criar uma Jogador.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarJogadorAsync([FromBody] JogadorInputModel inputModel)
        {
            var commands = new CriarJogadorCommand(inputModel);

            await _mediator.Send(commands);

            return Ok();
        }

        /// <summary>
        /// Rota para listagem de Jogadors com suporte a paginação e filtros opcionais
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="pagina"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarJogadorAsync(
            [FromQuery] JogadorFiltroInputModel inputModel,
            [Required] int pagina,
            [Required] int limite
        )
        {
            var query = new ListarJogadorQuery(inputModel, pagina, limite);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Rota responsável por editar Jogador
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarJogadorAsync(
            List<EditarJogadorInputModel> inputModel
        )
        {
            var command = new EditarJogadorCommand(inputModel);

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Rota responsável por excluir Jogador
        /// </summary>
        /// <param name="inputModels"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExcluirJogadorAsync(List<int> inputModels)
        {
            var command = new ExcluirJogadorCommand(inputModels);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
