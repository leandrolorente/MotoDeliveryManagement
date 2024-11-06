using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Queries.LocacaoQueries;
using MotoDelivery.Application.Requests.LocacaoRequests;
using MotoDelivery.Application.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("locacao")]
    [Tags("locação")]
    public class LocacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Realizar uma locação de moto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Alugar uma moto")]
        public async Task<IActionResult> PostLocacao([FromBody] RegistrarLocacaoRequest request)
        {
            var response = await _mediator.Send(new CreateLocacaoCommand(request));
            if (response != 0)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new Response(false, "Dados inválidos"));
        }

        /// <summary>
        /// Consultar locação por id
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar locação por id")]
        public async Task<IActionResult> GetLocacaoById(string id)
        {
            if (!long.TryParse(id, out var locacaoId))
            {
                return BadRequest(new Response(false, "ID inválido. O ID deve ser um número inteiro válido."));
            }

            var locacao = await _mediator.Send(new ConsultarLocacaoPorIdQuery(locacaoId));
            if (locacao == null)
                return NotFound(new Response(false, "Locação não encontrada"));

            return Ok(locacao);
        }

        /// <summary>
        /// Informar data de devolução da locação
        /// </summary>
        [HttpPut("{id}/devolucao")]
        [SwaggerOperation(Summary = "Informar data de devolução e calcular valor")]
        public async Task<IActionResult> DevolverLocacao(string id, [FromBody] InformarDevolucaoRequest request)
        {
            if (!long.TryParse(id, out var devolucaoId))
            {
                return BadRequest(new Response(false, "ID inválido. O ID deve ser um número inteiro válido."));
            }

            var response = await _mediator.Send(new InformarDevolucaoCommand(devolucaoId, request.DataDevolucao));
            if (response)
                return Ok(new Response(true, "Data de devolução informada com sucesso"));

            return BadRequest(new Response(false, "Dados inválidos"));
        }
    }
}
