using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotoDelivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntregadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastrar um entregador
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEntregador([FromBody] EntregadorRequest request)
        {
            var response = await _mediator.Send(new CadastrarEntregadorCommand(request));
            if (response.Sucesso)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(new { mensagem = "Dados inválidos" });
        }

        /// <summary>
        /// Enviar foto da CNH
        /// </summary>
        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> PostFotoCNH(string id, [FromBody] EntregadorRequest request)
        {
            var response = await _mediator.Send(new EnviarFotoCNHCommand(id, request.ImagemCNH));
            if (response.Sucesso)
                return Ok();

            return BadRequest(new { mensagem = "Dados inválidos" });
        }
    }
}
