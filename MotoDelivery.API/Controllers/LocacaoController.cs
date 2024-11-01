using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> PostLocacao([FromBody] LocacaoRequest request)
        {
            var response = await _mediator.Send(new RegistrarLocacaoCommand(request));
            if (response.Sucesso)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Consultar locação por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocacaoById(string id)
        {
            var locacao = await _mediator.Send(new ConsultarLocacaoPorIdQuery(id));
            if (locacao == null)
                return NotFound(new { mensagem = "Locação não encontrada" });

            return Ok(locacao);
        }

        /// <summary>
        /// Informar data de devolução da locação
        /// </summary>
        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> DevolverLocacao(string id, [FromBody] LocacaoRequest request)
        {
            var response = await _mediator.Send(new InformarDevolucaoCommand(id, request.DataDevolucao));
            if (response.Sucesso)
                return Ok(new { mensagem = "Data de devolução informada com sucesso" });

            return BadRequest(new { mensagem = "Dados inválidos" });
        }
    }
}
