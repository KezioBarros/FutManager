using System.ComponentModel.DataAnnotations;
using Application.Commands.CriarPosicaoJogador;
using Application.Commands.EditarPosicaoJogador;
using Application.Commands.ExcluirPosicaoJogador;
using Application.Querys.ListarPosicaoJogador;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/PosicaoJogador")]
    public class PosicaoJogadorController : MainController
    {
        private readonly IMediator _mediator;

        public PosicaoJogadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rota responsável por criar uma Posicao de Jogador.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarPosicaoJogadorAsync(
            [FromBody] PosicaoJogadorInputModel inputModel
        )
        {
            var commands = new CriarPosicaoJogadorCommand(inputModel);

            await _mediator.Send(commands);

            return Ok();
        }

        /// <summary>
        /// Rota para listagem de Posicao de Jogadors com suporte a paginação e filtros opcionais
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="pagina"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarPosicaoJogadorAsync(
            [FromQuery] PosicaoJogadorFiltroInputModel inputModel,
            [Required] int pagina,
            [Required] int limite
        )
        {
            var query = new ListarPosicaoJogadorQuery(inputModel, pagina, limite);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Rota responsável por editar Posicao de Jogador
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarPosicaoJogadorAsync(
            List<EditarPosicaoJogadorInputModel> inputModel
        )
        {
            var command = new EditarPosicaoJogadorCommand(inputModel);

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Rota responsável por excluir Posicao de Jogador
        /// </summary>
        /// <param name="inputModels"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExcluirPosicaoJogadorAsync(List<int> inputModels)
        {
            var command = new ExcluirPosicaoJogadorCommand(inputModels);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
