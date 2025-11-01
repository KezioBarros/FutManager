using System.ComponentModel.DataAnnotations;
using Application.Commands.CriarUsuario;
using Application.Commands.EditarUsuario;
using Application.Commands.ExcluirUsuario;
using Application.Querys.ListarUsuario;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : MainController
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rota responsável por criar um Usuario.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarUsuarioAsync([FromBody] UsuarioInputModel inputModel)
        {
            var commands = new CriarUsuarioCommand(inputModel);

            await _mediator.Send(commands);

            return Ok();
        }

        /// <summary>
        /// Rota para listagem de Usuarios com suporte a paginação e filtros opcionais
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="pagina"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarUsuarioAsync(
            [FromQuery] UsuarioFiltroInputModel inputModel,
            [Required] int pagina,
            [Required] int limite
        )
        {
            var query = new ListarUsuarioQuery(inputModel, pagina, limite);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Rota responsável por editar Usuario
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarUsuarioAsync(
            List<EditarUsuarioInputModel> inputModel
        )
        {
            var command = new EditarUsuarioCommand(inputModel);

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Rota responsável por excluir Usuario
        /// </summary>
        /// <param name="inputModels"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExcluirUsuarioAsync(List<int> inputModels)
        {
            var command = new ExcluirUsuarioCommand(inputModels);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
