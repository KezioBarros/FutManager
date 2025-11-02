using Application.Commands.Autenticacao;
using Core.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/autenticacao")]
    public class AutenticacaoController : MainController
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Autentica o usuário e gera um token de acesso JWT.
        /// </summary>
        /// <param name="InputModel"></param>
        /// <returns></returns>
        [HttpPost("gerar-token")]
        [AllowAnonymous]
        public async Task<IActionResult> GerarTokenAsync(
            [FromBody] UsuarioAutenticacaoInputModel InputModel
        )
        {
            var command = new GerarTokenCommand(InputModel);
            var autenticacaoResult = await _mediator.Send(command);

            return Ok(autenticacaoResult);
        }
    }
}
