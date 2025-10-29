using System.ComponentModel.DataAnnotations;
using Application.Commands;
using Application.Commands.EditarHorario;
using Application.Commands.ExcluirHorario;
using Application.Queries.ListarHorarios;
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
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriaNovoHorarioAsync(HorarioInputModel inputModel)
        {
            var command = new CriaNovoHorarioCommand(inputModel);
            var horario = await _mediator.Send(command);

            return Ok(horario);
        }

        /// <summary>
        /// Rota para listagem de horários com suporte a paginação e filtros opcionais
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="pagina"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarHorariosAsync(
            [FromQuery] HorarioFiltroInputModel inputModel,
            [Required] int pagina,
            [Required] int limite
        )
        {
            var query = new ListarHorariosQuery(inputModel, pagina, limite);

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Rota responsável por editar horários
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarHorarioAsync(
            List<EditarHorarioInputModel> inputModel
        )
        {
            var command = new EditarHorarioCommand(inputModel);

            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Rota responsável por excluir horários
        /// </summary>
        /// <param name="horarioIds"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ExcluirHorarioAsync(List<int> horarioIds)
        {
            var command = new ExcluirHorarioCommand(horarioIds);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
